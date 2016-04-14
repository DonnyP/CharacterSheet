using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CharacterSheet
{
    public partial class MainForm : Form
    {
        public static List<Character> characterDB = new List<Character>();

        public MainForm()
        {
            InitializeComponent();
            loadDB();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreateForm cf = new CreateForm();
            cf.Show();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            ViewForm vf = new ViewForm();
            vf.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void loadDB()
        {
            string newName, newDexterity, newStrength, newHealth, newcharClass, newPerk;
            newName = newDexterity = newStrength = newHealth = newcharClass = newPerk = "";
            int index = 1;

            // Open the file to be read
            XmlTextReader reader = new XmlTextReader("characters.xml");

            // Continue to read each element and text until the file is done
            while (reader.Read())
            {
                // If the currently read item is text then print it to screen,
                // otherwise the loop repeats getting the next piece of information
                if (reader.NodeType == XmlNodeType.Text)
                {
                    if (index == 1)
                    {
                        newName = reader.Value;
                        index++;
                    }
                    else if (index == 2)
                    {
                        newDexterity = reader.Value;
                        index++;
                    }
                    else if (index == 3)
                    {
                        newStrength = reader.Value;
                        index++;
                    }
                    else if (index == 4)
                    {
                        newHealth = reader.Value;
                        index++;
                    }
                    else if (index == 5)
                    {
                        newcharClass = reader.Value;
                        index++;
                    }
                    else if (index == 6)
                    {
                        newPerk = reader.Value;
                        Character newCharacter = new Character(newName, newDexterity, newStrength, newHealth, newcharClass, newPerk);
                        characterDB.Add(newCharacter);
                        index = 1;
                    }
                }
            }
            // When done reading the file close it
            reader.Close();
        }
    }
}
