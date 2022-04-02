using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using CollinsDict.Properties;
using System.Text.RegularExpressions;

namespace CollinsDict
{
    public partial class Dict : Form
    {
        public class Word
        {
            public string text { get; set; }
            public long id { get; set; }
            public Word(string aText, long aId)
            {
                this.text = aText;
                this.id = aId;
            }

            public override string ToString() { return this.text; }
        }

        // Holds our connection with the database
        SQLiteConnection m_dbConnection;
        bool m_isInited = false;
        List<Word>[] m_words = new List<Word>[2];
        bool m_isPl = false;
        bool m_changing = false;
        bool m_isInSearch = false;
        bool m_isInSelect = false;
        string m_newWord = "";

        public Dict()
        {
            InitializeComponent();
        }

        private ListBox getLB() {
            if (m_isPl) {
                return lbWords_pl;
            } else {
                return lbWords;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fillWordsList()
        {
            if (!m_isInited) {
                for (int i = 0; i < 2; i++) {
                    string sql = "select * from word{0} order by id";
                    sql = String.Format(sql, i == 1 ? "_pl" : "");
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                    SQLiteDataReader reader = command.ExecuteReader();

                    m_words[i] = new List<Word>();
                    while (reader.Read()) {
                        m_words[i].Add(new Word((string)reader["text"], (long)reader["id"]));
                    }
                    if (i == 0) {
                        lbWords.DataSource = m_words[0];
                        lbWords.DisplayMember = "text";
                        lbWords.ValueMember = "id";
                    } else {
                        lbWords_pl.DataSource = m_words[1];
                        lbWords_pl.DisplayMember = "text";
                        lbWords_pl.ValueMember = "id";
                    }
                }
                m_isInited = true;
            }
            lbWords.Visible = !m_isPl;
            lbWords_pl.Visible = m_isPl;
        }

        private void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=dictsqlite3.db;Version=3;");
            m_dbConnection.Open();
        }

        private void fillEntry(long num)
        {
            string sql = "select * from entry{0} where word_id=" + num.ToString();
            sql = String.Format(sql, m_isPl ? "_pl" : "");

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            txtEntry.ResetText();

            if (reader.Read())
            {
                string s = @"{\rtf {\colortbl;\red128\green0\blue0;\red76\green23\blue139;}" + (string)reader["text_rtf"] + "}";
                txtEntry.Rtf = s;
            }
        }

        private void Dict_Load(object sender, EventArgs e)
        {
            initAll();
        }

        private void initAll()
        {
            initPos();
            connectToDatabase();
            initState();
            // we are switching to pl for a moment to force pl listbox to initiate properly to save time later
            setPl();
            setEng();
        }

        private void initPos()
        {
            // Set window location
            if (Settings.Default.WindowLocation != null)
            {
                Point savedLoc = Settings.Default.WindowLocation;
                if (IsOnScreen(savedLoc))
                {
                    this.Location = savedLoc;
                }
            }

            // Set window size
            if (Settings.Default.WindowSize != null)
            {
                this.Size = Settings.Default.WindowSize;
            }
        }

        private bool IsOnScreen(Point formTopLeft)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                if (screen.WorkingArea.Contains(formTopLeft))
                {
                    return true;
                }
            }

            return false;
        }

        private void initState()
        {
            fillWordsList();
            cbDirection.SelectedIndex = m_isPl ? 1 : 0;
            pbFlag.Image = ilFlags.Images[m_isPl ? 1 : 0];
            txtEntry.Text = "";
            txtEntry.Rtf = "";
            txtEntry.ResetText();
            txInput.Text = m_newWord;
            m_newWord = "";
            txInput.Select();
        }

        private void lbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_isInSelect = true;
            fillEntry((long)lbWords.SelectedValue);
            if (!m_isInSearch)
            {
                txInput.Text = lbWords.Text;
            }
            m_isInSelect = false;
        }

        private void lbWords_pl_SelectedIndexChanged(object sender, EventArgs e) {
            m_isInSelect = true;
            fillEntry((long)lbWords_pl.SelectedValue);
            if (!m_isInSearch) {
                txInput.Text = lbWords_pl.Text;
            }
            m_isInSelect = false;
        }

        private void txInput_TextChanged(object sender, EventArgs e)
        {
            if (m_isInSelect) return;
            m_isInSearch = true;
            MatchWord(txInput.Text);
            m_isInSearch = false;
        }

        private void IncrementalSearch(char ch)
        {
            //if ((DateTime.Now - this.lastKeyPressTime) > new TimeSpan(0, 0, 1))
            //{
            //    this.searchString = ch.ToString();
            //}
            //else
            //{
            //    this.searchString += ch;
            //}
            //this.lastKeyPressTime = DateTime.Now;
            //* code falls over HERE *//
            string curVal = txInput.Text + ch;

            m_isInSearch = true;
            MatchWord(curVal);
            m_isInSearch = false;
        }

        private void MatchWord(string curVal)
        {
            var item =
                getLB().Items.Cast<Word>()
                    .FirstOrDefault(it => it.text.StartsWith(curVal, true, CultureInfo.InvariantCulture));

            if (item == null)
            {
                MatchWord(curVal.Remove(curVal.Length - 1));
                return;
            }
            var index = getLB().Items.IndexOf(item);
            if (index < 0) return;
            getLB().SelectedIndex = index;
        }

        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDict(cbDirection.SelectedIndex == 1);
        }

        private void setDict(bool isPl)
        {
            if (m_changing) return;
            m_changing = true;
            m_isPl = isPl;
            initState();
            m_changing = false;
        }

        private void setPl()
        {
            if (m_isPl) return;
            m_isPl = true;
            initState();
        }

        private void setEng()
        {
            if (!m_isPl) return;
            m_isPl = false;
            initState();
        }

        private void Dict_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    setEng();
                    e.Handled = true;
                    break;
                case Keys.F2:
                    setPl();
                    e.Handled = true;
                    break;
                case Keys.C:
                    if (e.Control && !e.Alt)
                    {
                        if (this.ActiveControl.Name == "txtEntry")
                        {
                            Clipboard.SetText(txtEntry.SelectedText);
                            e.Handled = true;
                        }
                        else if (this.ActiveControl.Name == "txInput")
                        {
                            Clipboard.SetText(txInput.SelectedText);
                            e.Handled = true;
                        }
                        else if (this.ActiveControl.Name == "lbWords" || this.ActiveControl.Name == "lbWords_pl")
                        {
                            Clipboard.SetText(getLB().Text);
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    else
                    {
                        e.Handled = false;
                    }
                    break;
                case Keys.Escape:
                    txInput.Text = "";
                    txInput.Select();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void Dict_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Copy window location to app settings
            Point currLoc = this.Location;
            if (IsOnScreen(currLoc))
            {
                Settings.Default.WindowLocation = currLoc;
            }

            // Copy window size to app settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            // Save settings
            Settings.Default.Save();
        }

        private void txtEntry_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selRtf = txtEntry.SelectedRtf;
            if (Regex.Replace(selRtf, @"{.*}", String.Empty).Split(' ')[0].Contains("\\cf1"))
            {
                m_newWord = txtEntry.SelectedText.Trim();
                // it means this is explanation - language has to be changed
                setDict(isPl: !m_isPl);
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(100);
            }
            else
            {
                txInput.Text = txtEntry.SelectedText.Trim();
            }
        }

        private void pbFlag_Click(object sender, EventArgs e)
        {
            setDict(isPl: !m_isPl);
        }
    }
}
