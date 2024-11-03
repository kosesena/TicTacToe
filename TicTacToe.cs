using System;

namespace TicTacToe
{
    class Program
    {
        //Character array representing the game board
        //Oyun tahtasını temsil eden karakter dizisi
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
       
        //Variable to track the current player: 1=X(Player1),2=0(Player2)
        //Şu anki oyuncuyu takip eden değişken: 1=X(Oyuncu1),2=0(Oyuncu2)
        static int currentPlayer = 1; 
        
        //Variable to store the player's choice of board position 
        //Oyuncunun tahtada seçtiği hücreyi takip eden değişken
        static int choice;
        
        //Flag to check the game status: 1=win, -1=draw, 0=continue
        //Oyunun durumunu kontrol eden bayrak: 1=kazanma, -1=berabere, 0=devam
        static int flag = 0; 

        static void Main(string[] args)
        {
            //Game loop continues until there is a win or a draw
            //Oyun döngüsü,kazanan biri olana ya da oyun berabere bitene kadar devam eder
            do
            {
                //Clears the console screen to refresh the board display
                //Konsol ekranını temizleyerek tahtayı günceller
                Console.Clear();
                
                //Displays information about players
                //Oyuncular hakkında bilgi gösterir
                Console.WriteLine("Player 1: X and Player 2: O"); // Player's symbols / Oyuncuların sembolleri
                Console.WriteLine("\n");
                
                // Displays the current player's turn
                //Şu anki oyuncunun sırasını gösterir
                if (currentPlayer % 2 == 0)
                {
                    Console.WriteLine("Turn: Player 2 (O)");
                }
                else
                {
                    Console.WriteLine("Turn: Player 1 (X)");
                }
                Console.WriteLine("\n");
                
                // Display the game board
                // Oyun tahtasını görüntüler
                DisplayBoard();
                
                // Prompts player to choose a board position
                // Oyuncudan tahtada bir pozisyon seçmesi istenir
                choice = int.Parse(Console.ReadLine());

                // Check if the chosen cell is already marked
                // Seçilen hücrenin işaretli olup olmadığını kontrol eder
                if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    if (currentPlayer % 2 == 0)
                    {
                        board[choice - 1] = 'O';
                        currentPlayer++; // Switch to the next player / Sırayı diğer oyuncuya geçirin
                    }
                    else
                    {
                        board[choice - 1] = 'X';
                        currentPlayer++;
                    }
                }
                else
                {
                    //If the cell is already occupied, display a warning message
                    //Hücre zaten doluysa,uyarı mesajı görüntüler
                    Console.WriteLine("Sorry, the row {0} is already marked with {1}", choice, board[choice - 1]);
                    Console.WriteLine("Please wait 2 seconds, loading...");
                    
                    //Wait for 2 seconds before refreshing
                    //Ekran yenlemeden önce 2 saniye bekler
                    System.Threading.Thread.Sleep(2000);
                }
                //Checks the game status after each move
                //Her hamleden sonra oyunun durumunu kontrol eder
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);
           
            // Display the final result
            // Sonucu göster
            Console.Clear();
            DisplayBoard();
            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (currentPlayer % 2) + 1);
            }
            else
            {
                //Display a message for a draaw
                //Beraberlik durumunda mesaj göster
                Console.WriteLine("The game is a draw.");
            }
            //Waits for user input to view the result before closing
            //Kapanmadan önce sonucu görmek için kullanıcıdan giriş bekler
            Console.ReadLine();
        }

        //Method to display the game board
        //Oyun tahtasını görüntüleyen metot
        private static void DisplayBoard()
        {
            //Display the 3x3 boardlayout
            //3x3 tahtanın düzenini gösterir
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", board[0], board[1], board[2]);
            Console.WriteLine("  __ |_    | __   ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", board[3], board[4], board[5]);
            Console.WriteLine("  __ |_    | __   ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }
        // Method to check for a win or a draw
        // Kazanma veya berabere durumunu kontrol eden metot
        private static int CheckWin()
        {
            //Check for horizontal win conditions
            //Yatay kazanma koşullarını kontrol eder
            if (board[0] == board[1] && board[1] == board[2])
                return 1;
            else if (board[3] == board[4] && board[4] == board[5])
                return 1;
            else if (board[6] == board[7] && board[7] == board[8])
                return 1;
           
            //Check for vertical win conditions
            //Dikey kazanma koşullarını kontrol eder
            else if (board[0] == board[3] && board[3] == board[6])
                return 1;
            else if (board[1] == board[4] && board[4] == board[7])
                return 1;
            else if (board[2] == board[5] && board[5] == board[8])
                return 1;
            
            //Check for diagonal win conditions
            //Çapraz kazanma koşullarını kontrol eder
            else if (board[0] == board[4] && board[4] == board[8])
                return 1;
            else if (board[2] == board[4] && board[4] == board[6])
                return 1;
           
            //Check for a draw condition
            //Berabere durumunu kontrol eder
            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
                return -1;
            
            //Game continues if no win or draw
            //Kazanan veya berabere yoksa oyun devam eder
            else
                return 0;
        }
    }
}