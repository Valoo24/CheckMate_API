namespace CheckMate_API.Tools
{
    public class PasswordGenerator
    {
        public string[] Characters { get; set; }
        public string[] CapitalizedCharacters { get; set; }
        public string[] Numbers { get; set; }
        public string[] Specials { get; set; }
        public List<string[]> ArrayList { get; set; }
        public PasswordGenerator()
        {
            Characters = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            CapitalizedCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Specials = new string[] { "&", "@", "#", "(", "§", "^", "!", "{", "}", ")", "°", "-", "_", "[", "]", "$", "*", "%", "µ", "£", ",", "?", ";", ".", ":", "/", "<", ">", "=", "+", "~" };
            ArrayList.Add(Characters);
            ArrayList.Add(CapitalizedCharacters);
            ArrayList.Add(Numbers);
            ArrayList.Add(Specials);
        }

        public string GenrerateNewRandomPassword()
        {
            string RandomPassword = string.Empty;

            for(int i = 0; i < 8; i++)
            {
                Random rnd = new Random();
                Random rnd2 = new Random();
                string[] RandomArray = ArrayList[rnd.Next(ArrayList.Count)];


                RandomPassword += RandomArray[rnd2.Next(RandomArray.Length)];
            }

            return RandomPassword;
        }
    }
}