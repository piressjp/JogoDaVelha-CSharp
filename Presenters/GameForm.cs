using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class GameForm : Form
    {
        private bool playerTurn; // true = X, false = O
        private int turnCount; // Contador de turnos
        private bool vsMachine; // true = contra a maquina
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonRestart;
        private Label labelStatus;
        private Button[,] board;

        public GameForm(bool _vsMachine)
        {
            vsMachine = _vsMachine;
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            buttonRestart.Hide();
            playerTurn = true; // X começa
            turnCount = 0;
            board = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 }
            };
            foreach (Button button in board)
            {
                button.Text = "";
                button.Click += new EventHandler(Button_Click);
            }
            labelStatus.Text = "Jogador X começa!";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Text == "")
            {
                if (playerTurn)
                {
                    clickedButton.Text = "X";
                }
                else
                {
                    clickedButton.Text = "O";
                }

                playerTurn = !playerTurn;
                turnCount++;
                CheckForWinner();
            }
        }

        private async Task CheckForWinner()
        {
            bool winnerFound = false;
            // Verificar linhas, colunas e diagonais para um vencedor
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0].Text == board[i, 1].Text) && (board[i, 1].Text == board[i, 2].Text) && (board[i, 0].Text != ""))
                {
                    winnerFound = true;
                }
                if ((board[0, i].Text == board[1, i].Text) && (board[1, i].Text == board[2, i].Text) && (board[0, i].Text != ""))
                {
                    winnerFound = true;
                }
            }
            if ((board[0, 0].Text == board[1, 1].Text) && (board[1, 1].Text == board[2, 2].Text) && (board[0, 0].Text != ""))
            {
                winnerFound = true;
            }
            if ((board[0, 2].Text == board[1, 1].Text) && (board[1, 1].Text == board[2, 0].Text) && (board[0, 2].Text != ""))
            {
                winnerFound = true;
            }

            if (winnerFound)
            {
                DisableButtons();
                string winner = playerTurn ? "O" : "X";
                labelStatus.Text = $"Jogador {winner} ganhou!";
                buttonRestart.Show();
            }
            else if (turnCount == 9)
            {
                labelStatus.Text = "Empate!";
                buttonRestart.Show();
            }
            else
            {
                labelStatus.Text = playerTurn ? "Vez do jogador X!" : "Vez do jogador O!";

                if (vsMachine && !playerTurn)
                {
                    await Task.Delay(1000);

                    // Lista para armazenar as posições possíveis (índices de posições vazias)
                    List<(int row, int column)> possibles = new List<(int row, int column)>();

                    for (int row = 0; row < board.GetLength(0); row++)
                    {
                        for (int column = 0; column < board.GetLength(1); column++)
                        {
                            // Verifica se a posição no tabuleiro está vazia
                            if (board[row, column].Text == "")
                            {
                                // Adiciona a posição (linha, coluna) à lista de posições possíveis
                                possibles.Add((row, column));
                            }
                        }
                    }

                    // Verifica se existem posições possíveis
                    if (possibles.Count > 0)
                    {
                        // Gera um índice aleatório da lista de possíveis
                        Random rand = new Random();
                        int index = rand.Next(possibles.Count);

                        var selectedPosition = possibles[index];

                        // Use selectedPosition.row e selectedPosition.column para definir a jogada da máquina
                        int selectedRow = selectedPosition.row;
                        int selectedColumn = selectedPosition.column;

                        // Aqui você pode marcar o tabuleiro com a jogada da máquina
                        board[selectedRow, selectedColumn].Text = "O";
                    }

                    turnCount++;
                    playerTurn = !playerTurn;
                    CheckForWinner();
                }
            }
        }

        private void DisableButtons()
        {
            foreach (Button button in board)
            {
                button.Enabled = false;
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            InitializeGame();
            foreach (Button button in board)
            {
                button.Enabled = true;
            }
        }
    }
}
