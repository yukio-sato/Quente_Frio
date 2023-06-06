string answer;
int rando, nr, chances, dist;
bool victory;
void dialog(string txt, int cooldown)
{
    for (int i = 0; i < txt.Length; i++)
    {
        Console.Write(txt[i]);
        if (txt[i].ToString() != " " || txt[i].ToString() != "-" || txt[i].ToString() != "{" || txt[i].ToString() != "}")
        {
        Thread.Sleep(cooldown);
        }
    }
}
void game()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    dialog($"Palpites: {chances}\n", 25);
    Console.ForegroundColor = ConsoleColor.Yellow;
    dialog("Digite um número: ", 25);
    Console.ForegroundColor = ConsoleColor.White;
    answer = Console.ReadLine()!;
    if (int.TryParse(answer, out nr))
    {
        nr = int.Parse(answer);
        dist = Math.Abs(nr - rando);
        if (nr > 0 && nr <= 100)
        {
        if (nr == rando)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            dialog("Achou o número!\n",25);
            victory = true;
        }
        else if (dist <= 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            dialog("Pelando.\n",25);
        }
        else if (dist <= 10)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            dialog("Quente.\n",25);
        }
        else if (dist >= 30)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            dialog("Congelando.\n",25);
            if (nr-rando < 0)
            {
            Console.ForegroundColor = ConsoleColor.Cyan;
            dialog("O número é maior. . .\n",25);   
            }
            else
            {
            Console.ForegroundColor = ConsoleColor.Cyan;
            dialog("O número é menor. . .\n",25);   
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            dialog("Frio.\n",25);
            if (nr-rando < 0)
            {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            dialog("O número é maior. . .\n",25);   
            }
            else
            {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            dialog("O número é menor. . .\n",25);   
            }
        }
        chances = chances - 1;
        Console.ForegroundColor = ConsoleColor.Yellow;
        dialog("Pressione qualquer tecla para continuar. . .\n",5);
        Console.ReadKey();
        if (chances > 0 && victory == false)
        {
            game();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            dialog("Fim de jogo!\n",5);
        }
        }
        else
        {
            game();
        }
    }
    else
    {
        game();
    }
}
Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkRed;
dialog(" - - = { Quente", 25);
Console.ForegroundColor = ConsoleColor.White;
dialog(" e ",25);
Console.ForegroundColor = ConsoleColor.DarkCyan;
dialog("Frio } = - -\n\n\n", 25);
Console.ForegroundColor = ConsoleColor.DarkYellow;
dialog("Instruções:\n",10);
Console.ForegroundColor = ConsoleColor.Green;
dialog("Como começar?\n",10);
Console.ForegroundColor = ConsoleColor.White;
dialog("O jogo começa quando você apertar qualquer tecla do computador.\n\n",10);
Console.ForegroundColor = ConsoleColor.Green;
dialog("Como jogar?\n",10);
Console.ForegroundColor = ConsoleColor.White;
dialog("Após de inicia-lo, deve descobrir o número utilizando palpites, caso esteja perto exibirá a palavra relacionada com: ",10);
Console.ForegroundColor = ConsoleColor.Red;
dialog("Quente",10);
Console.ForegroundColor = ConsoleColor.White;
dialog(", caso contrário ele exibirá a palavra relacionadas com: ",10);
Console.ForegroundColor = ConsoleColor.Cyan;
dialog("Frio",10);
Console.ForegroundColor = ConsoleColor.White;
dialog(".\n\n",10);
Console.ForegroundColor = ConsoleColor.Green;
dialog("Como ganhar?\n",10);
Console.ForegroundColor = ConsoleColor.White;
dialog("Acertando o número utilizando 7 palpites ou menos.\n\n",10);
Console.ForegroundColor = ConsoleColor.Green;
dialog("Como perder?\n",10);
Console.ForegroundColor = ConsoleColor.White;
dialog("Caso esgote todos os palpites.\n\n",10);
Console.ForegroundColor = ConsoleColor.Yellow;
dialog("Pressione qualquer tecla para continuar. . .\n",5);
Console.ReadKey();
rando = new Random().Next(1,101);
chances = 7;
victory = false;
game();
Console.ResetColor();