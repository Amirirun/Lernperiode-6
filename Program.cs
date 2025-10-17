
using Lernperiode_6.Bösewicht;
using Lernperiode_6.Held;
using Lernperiode_6;
using mini_game;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Data;


namespace Lern_periode_6
{
    internal class Program
    {
        static async Task TypeWriteAsync(string text, int delayMs = 50)
        {
            foreach (char ch in text)
            {
                Console.Write(ch);
                await Task.Delay(delayMs);
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {  


            Michael_Scofield Held2 = new Michael_Scofield("Michael Scofield", "Brechstange", "Hochbegabt", 60, 10);
            Hulk Held1 = new Hulk("Hulk", 1990, 100, 50);
            Spiderman Held3 = new Spiderman("Spiderman", "Spinnetz", "Spinnensinn", 60, 17);





            Bösemann Bösewicht1 = new Bösemann("Bösemann", 200, 50, 80);
            Silversurfer Bösewicht2 = new Silversurfer("Silver_Surfer", "Surf Board", "Fliegen", 65, 18);
            Thanos Bösewicht3 = new Thanos("Thanos", "Goldener Handschuh", "Ultimative zerstörung", 350, 20, 10000);



            Heiltrank heil = new Heiltrank(30, 5);
            Hammer hammer = new Hammer("Hammer", 4, 30);
            Axt axt = new Axt("Axt", 2, 23);
            Schwert schwert = new Schwert("Schwert", 7, 50);
            Keule keule = new Keule("Keule", 5, 40);
            Bogen bogen = new Bogen("Bogen", 6, 45);



            // Held1
            Console.WriteLine("Name: " + Held1.Name);
            Console.WriteLine("Id: " + Held1.Id);
            Console.WriteLine("Dein Gold im Tresor:" + Held1.Gold);
            Console.WriteLine("Afangsleben:" + Held1.Leben);

            Console.WriteLine("Beovr du Anfagen kannst musst du in den Shop und dich ausrüsten!");
            Console.WriteLine();
            Console.WriteLine("Stats für Hammer(H):");
            Console.WriteLine("Damage:" + hammer.Damage);
            Console.WriteLine("Price:" + hammer.Price);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Stats für Axt(A):");
            Console.WriteLine("Damage:" + axt.Damage);
            Console.WriteLine("Price:" + axt.Price);
            Console.WriteLine();
            Console.WriteLine();





            TypeWriteAsync("Welche Waffe möchtest du dir für den Anfang kaufen (H/A)?", 50);

            string waffeneingabe = Console.ReadLine()?.Trim().ToUpper();

            if (waffeneingabe == "H")
            {

                if (Held1.TrySpendGold(hammer.Price))
                {

                    Console.WriteLine("Glückwunsch zu deinem Kauf!");
                    Console.WriteLine($"Gekauft: {hammer.Name} (-{hammer.Price} Gold)");
                    Console.WriteLine("Gold jetzt:" + Held1.Gold);

                }

                else
                {

                    Console.WriteLine("Zu wenig Gold");
                    return;

                }

            }

            else if (waffeneingabe == "A")
            {

                if (Held1.TrySpendGold(axt.Price))
                {

                    Console.WriteLine("Glückwunsch zu deinem Kauf!");
                    Console.WriteLine($"Gekauft: {axt.Name} (-{axt.Price} Gold)");
                    Console.WriteLine("Gold jetzt:" + Held1.Gold);

                }

                else
                {

                    Console.WriteLine("Zu wenig Gold");
                    return;

                }

            }

            else
            {

                Console.WriteLine("Ungültige Eingabe");

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");






            TypeWriteAsync($"Möchtest du auch noch einen Heiltrank(ja/nein) kaufen für {heil.Price}?", 50);

            string heiltrankeingabe = Console.ReadLine();


            if (heiltrankeingabe == "ja")
            {

                if (Held1.TrySpendGold(heil.Price))
                {

                    heil.Anwenden(Held1);

                    Console.WriteLine($"Gekauft: Heiltrank (-{heil.Price} Gold)");
                    Console.WriteLine("In deinem Tresor ist noch:" + Held1.Gold);

                }

            }

            else
            {

                Console.WriteLine($"{Held1.Name} trinkt keinen Heiltrank.");

            }

            Console.WriteLine("Leben nach dem Trank:" + Held1.Leben);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DU bist bereit für den Kampf gegen Bösemann");
            Console.ResetColor();

            int schadenProSchlag = 1;
            string waffenName = "?";

            if (waffeneingabe == "H")
            {

                schadenProSchlag = hammer.Damage;
                waffenName = hammer.Name;

            }

            else if (waffeneingabe == "A")
            {

                schadenProSchlag = axt.Damage;
                waffenName = axt.Name;

            }

            else
            {

                Console.WriteLine("Ungültige Eingabe. Bitte H oder A.");
                return;

            }


            Console.WriteLine();
            Console.WriteLine($"Kampf gegen {Bösewicht1.Name}! Waffe: {waffenName} (DMG {schadenProSchlag})");
            Console.WriteLine("Drücke [LEERTASTE] zum Zuschlagen, [ESC] zum Abbrechen.");

            bool abgebrochen = false;
            bool hatGewonnen = false;

            try
            {
                while (Held1.Leben > 0 && Bösewicht1.Leben > 0)
                {
                    int hits = 0, dealt = 0;
                    var sw = Stopwatch.StartNew();

                    while (sw.Elapsed < TimeSpan.FromSeconds(5))
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(intercept: true).Key;

                            if (key == ConsoleKey.Escape)
                            {
                                abgebrochen = true;
                                break;
                            }

                            if (key == ConsoleKey.Spacebar)
                            {
                                hits++;
                                dealt += schadenProSchlag;
                                Console.Write($"\rTreffer: {hits}, geplanter Schaden: {dealt}   ");
                            }
                        }

                        Thread.Sleep(10);
                    }

                    Console.WriteLine();
                    if (abgebrochen) break;
                    Bösewicht1.Leben = Math.Max(0, Bösewicht1.Leben - dealt);

                    Console.WriteLine($"Deine Treffer: {hits}  ->  Schaden: {dealt}");
                    Console.WriteLine($"{Bösewicht1.Name} HP: {Bösewicht1.Leben}");


                    if (Bösewicht1.Leben <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Bösewicht1.Name} ist besiegt!");
                        Console.ResetColor();

                        if (Bösewicht1.Gold > 0)
                        {
                            Held1.AddGold(Bösewicht1.Gold);
                            Console.WriteLine($"+{Bösewicht1.Gold} Gold Beute");
                            Bösewicht1.Gold = 0;
                        }

                        hatGewonnen = true;
                        break;
                    }

                    Held1.Leben = Math.Max(0, Held1.Leben - Bösewicht1.Damage);
                    Console.WriteLine($"{Bösewicht1.Name} schlägt zurück! -{Bösewicht1.Damage} HP  ->  Dein Leben: {Held1.Leben}");
                    Console.WriteLine("-------------------------------------------------------------");


                    if (Held1.Leben <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du wurdest besiegt…");
                        Console.ResetColor();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[Fehler] {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }

            if (hatGewonnen && !abgebrochen)
            {
                Console.WriteLine();
                Console.WriteLine("Dein Gold im Tresor beträgt: " + Held1.Gold);
                Console.WriteLine("Du hast neue Waffen freigeschaltet!");

                Console.WriteLine();
                Console.WriteLine("Stats für Schwert (S):  DMG " + schwert.Damage + "  Preis " + schwert.Price);
                Console.WriteLine("Stats für Keule  (K):  DMG " + keule.Damage + "  Preis " + keule.Price);
                Console.WriteLine("Stats für Bogen  (B):  DMG " + bogen.Damage + "  Preis " + bogen.Price);
                Console.Write("Waffe kaufen? (S/K/B): ");
                string wahl = Console.ReadLine()?.Trim().ToUpperInvariant();


                if (wahl == "S")
                {
                    schadenProSchlag = schwert.Damage;
                    waffenName = schwert.Name;
                }
                else if (wahl == "K")
                {
                    schadenProSchlag = keule.Damage;
                    waffenName = keule.Name;
                }
                else if (wahl == "B")
                {
                    schadenProSchlag = bogen.Damage;
                    waffenName = bogen.Name;
                }
                else
                {
                    Console.WriteLine("Du behältst deine alte Waffe.");
                }



            }
            else if (abgebrochen)
            {
                Console.WriteLine("Kampf abgebrochen.");
            }



            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DU bist bereit für den Kampf gegen Thanos!");
            Console.ResetColor();

            int schadenProSchlag2 = schadenProSchlag;
            string waffenName2 = waffenName;



            Console.WriteLine();
            Console.WriteLine($"Kampf gegen {Bösewicht3.Name}! Waffe: {waffenName2} (DMG {schadenProSchlag2})");
            Console.WriteLine("Drücke [LEERTASTE] zum Zuschlagen, [ESC] zum Abbrechen.");

            bool abgebrochen2 = false;
            bool hatGewonnen2 = false;

            try
            {
                while (Held1.Leben > 0 && Bösewicht3.Life > 0)
                {
                    int hits = 0, dealt = 0;
                    var sw = Stopwatch.StartNew();

                    while (sw.Elapsed < TimeSpan.FromSeconds(5))
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(intercept: true).Key;

                            if (key == ConsoleKey.Escape)
                            {
                                abgebrochen2 = true;
                                break;
                            }

                            if (key == ConsoleKey.Spacebar)
                            {
                                hits++;
                                dealt += schadenProSchlag2;
                                Console.Write($"\rTreffer: {hits}, geplanter Schaden: {dealt}   ");
                            }
                        }

                        Thread.Sleep(10);
                    }

                    Console.WriteLine();
                    if (abgebrochen2) break;

                    Bösewicht3.Life = Math.Max(0, Bösewicht3.Life - dealt);
                    Console.WriteLine($"Deine Treffer: {hits}  ->  Schaden: {dealt}");
                    Console.WriteLine($"{Bösewicht3.Name} HP: {Bösewicht3.Life}");

                    if (Bösewicht3.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Bösewicht3.Name} ist besiegt!");
                        Console.ResetColor();

                        if (Bösewicht3.Gold > 0)
                        {
                            Held1.AddGold(Bösewicht3.Gold);
                            Console.WriteLine($"+{Bösewicht3.Gold} Gold Beute");
                            Bösewicht3.Gold = 0;
                        }

                        hatGewonnen2 = true;
                        break;
                    }

                    Held1.Leben = Math.Max(0, Held1.Leben - Bösewicht3.Damage);
                    Console.WriteLine($"{Bösewicht3.Name} schlägt zurück! -{Bösewicht3.Damage} HP  ->  Dein Leben: {Held1.Leben}");
                    Console.WriteLine("-------------------------------------------------------------");

                    if (Held1.Leben <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du wurdest besiegt…");
                        Console.ResetColor();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[Fehler] {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();

            }

            if (hatGewonnen2 && !abgebrochen2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Glückwunsch! Du hast Thanos besiegt und das Spiel fertig gespielt!");
                Console.ResetColor();
                var wahl = Console.ReadLine()?.Trim().ToUpperInvariant();

            }
            else if (abgebrochen2)
            {
                Console.WriteLine("Kampf abgebrochen.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du hast verloren. Versuch es nochmal!");
                Console.ResetColor();
                var wahl = Console.ReadLine()?.Trim().ToUpperInvariant();
            }
        }


    }
}