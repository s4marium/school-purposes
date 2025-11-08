using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGuessApplication
{
    public partial class frmGuessWord : Form
    {
        private string targetWord = "computer";
        private StringBuilder maskedWord;
        private List<string> wrongGuesses;

        public frmGuessWord()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            maskedWord = new StringBuilder();
            
            for (int i = 0; i < targetWord.Length; i++)
            {
                if (i == 0 || i == targetWord.Length - 1)
                {
                    maskedWord.Append(targetWord[i]);
                }
                else
                {
                    maskedWord.Append('?');
                }
            }

            wrongGuesses = new List<string>();

            UpdateWordDisplay();
        }

        private void UpdateWordDisplay()
        {
            lblWordToGuess.Text = maskedWord.ToString();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            string userGuess = txtGuessInput.Text.Trim().ToLower();
            
            txtGuessInput.Clear();

            if (string.IsNullOrEmpty(userGuess))
            {
                MessageBox.Show("Please enter a word!", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userGuess.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
            {
                maskedWord.Clear();
                maskedWord.Append(targetWord);
                UpdateWordDisplay();
                
                MessageBox.Show("Correct guess!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ResetGame();
            }
            else
            {
                if (!wrongGuesses.Contains(userGuess))
                {
                    wrongGuesses.Add(userGuess);
                    listBoxWrongGuesses.Items.Add(userGuess);
                }

                MessageBox.Show("Wrong guess!\nTry again.", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtGuessInput.Focus();
        }

        private void ResetGame()
        {
            wrongGuesses.Clear();
            listBoxWrongGuesses.Items.Clear();

            string[] words = { "computer", "keyboard", "monitor", "software", "hardware", "internet", "database", "programming" };
            Random random = new Random();
            targetWord = words[random.Next(words.Length)];

            InitializeGame();
        }
    }
}
