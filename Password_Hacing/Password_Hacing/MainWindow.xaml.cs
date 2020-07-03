using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Password_Hacing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime date;
        public MainWindow()
        {            
            InitializeComponent();            
            Password_hac_Button.Click += (s, e) =>
            {
                File.WriteAllText(@"C:\Users\Vadim\Desktop\Password_Hacing\пароли.txt", string.Empty);
                password_generate();
            };            
        }

        

        

        private void password_generate()
        {
            Password_hac_Count.Content = "Колличество попыток : ";
            Time_Count.Content = "Затрачиваемое время : ";

            date = DateTime.Now;            

            DateTime ot = DateTime.Now;
            int count = 0;

            var passwd_hack = "";
            string text = Password_hac_TextBox.Text;

            var number = "0123456789";
            char[] number_char = number.ToCharArray();
            int indexOf_number = text.IndexOfAny(number_char) + 1;
            if (indexOf_number != 0) passwd_hack += "0123456789";

            var big_letter = "QWERTYUIOPASDFGHJKLZXCVBNM";
            char[] big_letter_char = big_letter.ToCharArray();
            int indexOf_big_letter = text.IndexOfAny(big_letter_char) + 1;
            if (indexOf_big_letter != 0) passwd_hack += "QWERTYUIOPASDFGHJKLZXCVBNM";

            var letter = "qwertyuiopasdfghjklzxcvbnm";
            char[] letter_char = letter.ToCharArray();
            int indexOf_letter = text.IndexOfAny(letter_char) + 1;
            if (indexOf_letter != 0) passwd_hack += "qwertyuiopasdfghjklzxcvbnm";

            var simvols = "!@#$%^&*()";
            char[] simvols_char = simvols.ToCharArray();
            int indexOf_simvols = text.IndexOfAny(simvols_char) + 1;
            if (indexOf_simvols != 0) passwd_hack += "!@#$%^&*()";



            if (passwd_hack != "")
            {
                var q = passwd_hack.Select(x => x.ToString());
                for (int i = 0; i < Password_hac_TextBox.Text.Length - 1; i++)
                    q = q.SelectMany(x => passwd_hack, (x, y) => x + y);
                foreach (var item in q)
                {
                    save_passwords(item);
                    Password_hac_Count.Content = "Колличество попыток : " + count++;
                    if (item == Password_hac_TextBox.Text)
                    {
                        Password_hac_Count.Content = "Колличество попыток : " + count++;
                        Itog_Lable.Content = "Пароль разгадан : " + item;
                        long tick = DateTime.Now.Ticks - date.Ticks;
                        DateTime stope = new DateTime();
                        stope = stope.AddTicks(tick);
                        Time_Count.Content = "Затрачиваемое время : " + string.Format("{0:HH:mm:ss:ff}", stope);
                                             
                        break;
                    }
                }
            } 
        }


        static void save_passwords(string passwords)
        {
            string writePath = @"C:\Users\Vadim\Desktop\Password_Hacing\пароли.txt";

            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(passwords);
                
            }
        }

        
    }

}

