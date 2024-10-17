using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        private Game hangmanGame;
        private Label lblWord;
        private TextBox txtGuess;
        private Button btnGuess;
        private Label lblMistakes;
        private PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            hangmanGame = new Game();
            hangmanGame.StartGame();

            this.Text = "Hangman Game";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Kelime gösterim etiketi
            lblWord = new Label();
            lblWord.Font = new Font("Arial", 24);
            lblWord.Location = new Point(20, 20);
            lblWord.AutoSize = true;
            this.Controls.Add(lblWord);

            // Tahmin giriş kutusu
            txtGuess = new TextBox();
            txtGuess.Location = new Point(20, 100);
            txtGuess.Width = 100;
            this.Controls.Add(txtGuess);

            // Tahmin butonu
            btnGuess = new Button();
            btnGuess.Text = "Tahmin Et";
            btnGuess.Location = new Point(140, 100);
            btnGuess.Click += BtnGuess_Click;
            this.Controls.Add(btnGuess);

            // Yanlış tahmin sayısı etiketi
            lblMistakes = new Label();
            lblMistakes.Location = new Point(20, 140);
            this.Controls.Add(lblMistakes);

            // Resim kutusu (adam asmaca)
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(20, 180);
            pictureBox.Size = new Size(200, 200);
            this.Controls.Add(pictureBox);

            // Oyunu başlat
            UpdateUI();
        }

        private void BtnGuess_Click(object sender, EventArgs e)
        {
            if (txtGuess.Text.Length > 0)
            {
                char guess = txtGuess.Text[0]; // İlk karakteri al
                hangmanGame.CheckGuess(guess); // Tahmin kontrolü
                UpdateUI();
                txtGuess.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen bir harf giriniz.");
            }
        }

        private void UpdateUI()
{
          lblWord.Text = Utils.GetMaskedWord(hangmanGame.GuessedLetters, hangmanGame.WordToGuess);
          lblMistakes.Text = $"Yanlış tahmin: {hangmanGame.Mistakes}";

          // Resim güncelleme
          pictureBox.Image = hangmanGame.GetHangmanImage();
    
          // Kazanma veya kaybetme durumu kontrolü
          if (Utils.IsWordGuessed(hangmanGame.GuessedLetters, hangmanGame.WordToGuess))
          {
             MessageBox.Show($"Tebrikler, doğru kelimeyi buldunuz: {hangmanGame.WordToGuess}");
             ResetGame();
          }
          else if (hangmanGame.Mistakes >= hangmanGame.MaxMistakes)
          {
             MessageBox.Show($"Maalesef kaybettiniz. Doğru kelime: {hangmanGame.WordToGuess}");
             ResetGame();
          }
        }


        private void ResetGame()
        {
            hangmanGame.StartGame();
            UpdateUI();
        }
    }
}

