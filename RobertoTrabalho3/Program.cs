using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace RobertoTrabalho3
{
    class Program
    {
        //----------------------------------- MATRIZ -------------------------------------
        static char[][] cacapalavra = new char[3][];
        static char[][] cacapalavrafake = new char[3][];
        //----------------------------------- GERA CAÇA PALAVRA --------------------------
        static void GeraCaca()
        {
            Random ran = new Random();
            int seleciona;
            for (int i = 0; i < cacapalavra.Length; i++)
            {
                for (int j = 0; j < cacapalavra[i].Length; j++)
                {
                    if (cacapalavra[i][j] == cacapalavra[0][0])
                    {
                        seleciona = ran.Next(0, 2);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'A';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'D';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[0][1])
                    {
                        seleciona = ran.Next(0, 2);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'E';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'F';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[0][2])
                    {
                        seleciona = ran.Next(0, 2);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'B';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'C';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[1][0])
                    {
                        seleciona = ran.Next(0, 3);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'G';
                        }
                        else if (seleciona == 1)
                        {
                            cacapalavra[i][j] = 'I';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'U';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[1][1])
                    {
                        seleciona = ran.Next(0, 3);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'H';
                        }
                        else if (seleciona == 1)
                        {
                            cacapalavra[i][j] = 'J';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'V';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[1][2])
                    {
                        seleciona = ran.Next(0, 2);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'K';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'L';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[2][0])
                    {
                        seleciona = ran.Next(0, 3);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'M';
                        }
                        else if (seleciona == 1)
                        {
                            cacapalavra[i][j] = 'O';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'Q';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[2][1])
                    {
                        seleciona = ran.Next(0, 3);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'N';
                        }
                        else if (seleciona == 1)
                        {
                            cacapalavra[i][j] = 'T';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'P';
                        }
                    }
                    if (cacapalavra[i][j] == cacapalavra[2][2])
                    {
                        seleciona = ran.Next(0, 3);
                        if (seleciona == 0)
                        {
                            cacapalavra[i][j] = 'R';
                        }
                        else if (seleciona == 1)
                        {
                            cacapalavra[i][j] = 'S';
                        }
                        else
                        {
                            cacapalavra[i][j] = 'Z';
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\junin\Desktop\RobertoTrabalho3\RobertoTrabalho3\UsersBD.mdf;Integrated Security=True");
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\entra21\Desktop\RobertoTrabalho3\RobertoTrabalho3\UsersBD.mdf;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader reader;
            char[] letras = new char[9];
            string User = "";
            string escolha = "";
            string palavra = "";
            int Score = 0;
            int count = 0;
            int pontuação = 0;
            bool erro = false;
            bool fecharJogo = false;
            //----------------------------------- MATRIZ COLUNAS -------------------------

            for (int i = 0; i < cacapalavra.Length; i++)
            {
                cacapalavra[i] = new char[3];
                cacapalavrafake[i] = new char[3];
            }
            //----------------------------------- DELETA USERS BD ------------------------
            //string deletar = "DELETE FROM dbo.UserInfos WHERE Score = 0";
            //cmd = new SqlCommand(deletar, connect);
            //connect.Open();
            //cmd.ExecuteNonQuery();
            //connect.Close();
            //----------------------------------- MENU -----------------------------------
            for (int i = 0; 3 > 0; i++)
            {
                if (fecharJogo == true)
                {
                    break;
                }
                erro = false;
                Console.Clear();
                Console.WriteLine("|¨¨¨¨¨¨¨¨¨¨¨¨ LISTA ¨¨¨¨¨¨¨¨¨¨¨¨|");
                Console.WriteLine("|                               |");
                Console.WriteLine("| v                           v |");
                Console.WriteLine("|                               |");
                // --- >>> LISTA DE USERS <<< ---
                string lista = "SELECT * FROM UserInfos";
                cmd = new SqlCommand(lista, connect);
                connect.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("    Nome: {0} | Score: {1}", reader["Name"], reader["Score"]);
                    Console.WriteLine("|                               |");
                }
                connect.Close();
                // --- >>> LISTA DE USERS <<< ---
                Console.WriteLine("| ^                           ^ |");
                Console.WriteLine("|                               |");
                Console.WriteLine("|        1 > ESCOLHA < 1        |");
                Console.WriteLine("|                               |");
                Console.WriteLine("|      2 > NOVO PLAYER < 2      |");
                Console.WriteLine("|                               |");
                Console.WriteLine("|      3 > FECHAR JOGO < 3      |");
                Console.WriteLine("|_______________________________|");
                try
                {
                    escolha = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro!");
                    Console.WriteLine("Voltando ao Menu!");
                    Thread.Sleep(1000);
                    erro = true;
                }
                if (erro == false)
                {
                    if (escolha == "1")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Escolha o USER: ");
                        try
                        {
                            User = Console.ReadLine();
                            string select = $"SELECT Name,Score FROM dbo.UserInfos WHERE Name = '{User}'";
                            cmd = new SqlCommand(select, connect);
                            connect.Open();
                            reader = cmd.ExecuteReader();
                            connect.Close();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Erro!");
                            Console.WriteLine("Voltando ao Menu!");
                            Thread.Sleep(1000);
                            erro = true;
                        }
                        if (erro == false)
                        {
                            GeraCaca();

                            for (int q = 0; 3 > 0; q++)
                            {
                                for (int w = 0; w < cacapalavra.Length; w++)
                                {
                                    for (int e = 0; e < cacapalavra[w].Length; e++)
                                    {
                                        cacapalavrafake[w][e] = cacapalavra[w][e];
                                    }
                                }
                                count = 0;
                                Console.Clear();
                                Console.WriteLine("|¨¨¨¨¨¨ CAÇA ¨¨¨ PALAVRAS ¨¨¨¨¨¨|");
                                Console.WriteLine("|            _______            |");
                                Console.WriteLine("|            |{0}|{1}|{2}|            |", cacapalavra[0][0], cacapalavra[0][1], cacapalavra[0][2]);
                                Console.WriteLine("|            |{0}|{1}|{2}|            |", cacapalavra[1][0], cacapalavra[1][1], cacapalavra[1][2]);
                                Console.WriteLine("|            |{0}|{1}|{2}|            |", cacapalavra[2][0], cacapalavra[2][1], cacapalavra[2][2]);
                                Console.WriteLine("|            ¨¨¨¨¨¨¨            |");
                                string select = $"SELECT Score FROM UserInfos WHERE Name = '{User}'";
                                cmd = new SqlCommand(select, connect);
                                connect.Open();
                                reader = cmd.ExecuteReader();
                                while (reader.Read())
                                {
                                    Console.WriteLine("            Score: " + reader["Score"]);
                                }
                                connect.Close();
                                Console.WriteLine("|                               |");
                                Console.WriteLine("|  1 > INSERIR UMA PALAVRA < 1  |");
                                Console.WriteLine("|                               |");
                                Console.WriteLine("|   2 > NOVO CAÇA PALAVRA < 2   |");
                                Console.WriteLine("|                               |");
                                Console.WriteLine("|      3 > FECHAR JOGO < 3      |");
                                Console.WriteLine("|_______________________________|");
                                try
                                {
                                    escolha = Console.ReadLine();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Erro!");
                                    Console.WriteLine("Voltando ao Menu!");
                                    Thread.Sleep(1000);
                                    erro = true;
                                }
                                if (erro == false)
                                {
                                    if (escolha == "1")
                                    {
                                        try
                                        {
                                            Console.WriteLine("Insira a Palavra: ");
                                            palavra = Console.ReadLine();
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Erro!");
                                            Console.WriteLine("Voltando ao Menu!");
                                            Thread.Sleep(1000);
                                            erro = true;
                                        }
                                        if (erro == false)
                                        {
                                            bool parar = false;
                                            bool achou = false;
                                            bool cancelar = false;
                                            int linha = 0;
                                            int coluna = 0;
                                            letras = palavra.ToCharArray(0, palavra.Length);
                                            for (int u = 0; u < letras.Length; u++)
                                            {
                                                parar = false;
                                                for (int p = 0; p < cacapalavra.Length; p++)
                                                {
                                                    for (int o = 0; o < cacapalavra[p].Length; o++)
                                                    {
                                                        if (achou == false)
                                                        {
                                                            if (letras[u] == cacapalavra[p][o])
                                                            {
                                                                count++;
                                                                parar = true;
                                                                achou = true;
                                                                linha = p;
                                                                coluna = o;
                                                                break;
                                                            }
                                                        }
                                                        if (achou == true)
                                                        {
                                                            if (linha == 0 && coluna == 0)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha][coluna + 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna + 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 0 && coluna == 1)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha][coluna - 1])
                                                                 || (letras[u] == cacapalavra[linha][coluna + 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna - 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna + 1]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 0 && coluna == 2)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha][coluna - 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna - 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 1 && coluna == 0)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha - 1][coluna])
                                                                 || (letras[u] == cacapalavra[linha - 1][coluna + 1])
                                                                 || (letras[u] == cacapalavra[linha][coluna + 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna + 1])
                                                                 || (letras[u] == cacapalavra[linha + 1][coluna]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 1 && coluna == 1)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha - 1][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna + 1])
                                                                || (letras[u] == cacapalavra[linha][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha][coluna + 1])
                                                                || (letras[u] == cacapalavra[linha + 1][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha + 1][coluna])
                                                                || (letras[u] == cacapalavra[linha + 1][coluna + 1]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 1 && coluna == 2)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha - 1][coluna])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha + 1][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha + 1][coluna]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 2 && coluna == 0)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha - 1][coluna])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna + 1])
                                                                || (letras[u] == cacapalavra[linha][coluna + 1]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 2 && coluna == 1)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna + 1])
                                                                || (letras[u] == cacapalavra[linha][coluna + 1]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else if (linha == 2 && coluna == 2)
                                                            {
                                                                if ((letras[u] == cacapalavra[linha - 1][coluna])
                                                                || (letras[u] == cacapalavra[linha - 1][coluna - 1])
                                                                || (letras[u] == cacapalavra[linha][coluna - 1]))
                                                                {
                                                                    for (int k = 0; k < cacapalavra.Length; k++)
                                                                    {
                                                                        for (int j = 0; j < cacapalavra[k].Length; j++)
                                                                        {
                                                                            if (letras[u] == cacapalavrafake[k][j])
                                                                            {
                                                                                cacapalavrafake[k][j] = 'X';
                                                                                linha = k;
                                                                                coluna = j;
                                                                                count++;
                                                                                achou = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                            else if (letras[u] == 'X')
                                                                            {
                                                                                cancelar = true;
                                                                                parar = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (parar == true)
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (parar == true)
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (cancelar == true)
                                                {
                                                    break;
                                                }
                                            }
                                            Console.WriteLine(count);
                                            pontuação = 0;
                                            select = $"SELECT Score FROM UserInfos WHERE Name = '{User}'";
                                            cmd = new SqlCommand(select, connect);
                                            connect.Open();
                                            reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                pontuação = Convert.ToInt32(reader["Score"]);
                                            }
                                            connect.Close();
                                            for (int h = 0; h < count; h++)
                                            {
                                                h += 2;
                                                pontuação++;
                                            }
                                            string update = $"UPDATE UserInfos Set Score = {pontuação} WHERE Name = '{User}'";
                                            cmd = new SqlCommand(update, connect);
                                            connect.Open();
                                            cmd.ExecuteNonQuery();
                                            connect.Close();
                                        }
                                    }
                                    else if (escolha == "2")
                                    {
                                        GeraCaca();
                                        cacapalavrafake = cacapalavra;
                                    }
                                    else if (escolha == "3")
                                    {
                                        fecharJogo = true;
                                        Console.WriteLine("Fechando o Jogo!");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Escolha Inválida!");
                                        Console.WriteLine("Voltando.");
                                        Thread.Sleep(300);
                                        Console.Clear();
                                        Console.WriteLine("Escolha Inválida!");
                                        Console.WriteLine("Voltando..");
                                        Thread.Sleep(300);
                                        Console.Clear();
                                        Console.WriteLine("Escolha Inválida!");
                                        Console.WriteLine("Voltando...");
                                        Thread.Sleep(300);
                                        Console.Clear();
                                    }
                                }
                            }
                        }
                    }
                    else if (escolha == "2")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Insira o Novo USER: ");
                        try
                        {
                            User = Console.ReadLine();
                            string insert = $"INSERT into UserInfos (Name,Score) values ('{User}',{Score})";
                            cmd = new SqlCommand(insert, connect);
                            connect.Open();
                            cmd.ExecuteNonQuery();
                            connect.Close();
                            Console.WriteLine("Player Criado!");
                            Console.WriteLine("Volte ao Menu para Escolher o Player!");
                            Console.WriteLine("> ENTER TO CONTINUE <");
                            Console.ReadLine();
                        }
                        catch (Exception)
                        {
                            connect.Close();
                            Console.WriteLine("Erro!");
                            Console.WriteLine("Player já Cadastrado!");
                            Console.WriteLine("Voltando ao Menu!");
                            Thread.Sleep(1000);
                            erro = true;
                        }
                    }
                    else if (escolha == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("Fechando o Programa!");
                        Thread.Sleep(1000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Escolha Inválida!");
                        Console.WriteLine("Voltando.");
                        Thread.Sleep(300);
                        Console.Clear();
                        Console.WriteLine("Escolha Inválida!");
                        Console.WriteLine("Voltando..");
                        Thread.Sleep(300);
                        Console.Clear();
                        Console.WriteLine("Escolha Inválida!");
                        Console.WriteLine("Voltando...");
                        Thread.Sleep(300);
                        Console.Clear();
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Agradeçemos por Jogar!");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Agradeçemos por Jogar!!");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Agradeçemos por Jogar!!!");
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}
