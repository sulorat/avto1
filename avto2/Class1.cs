using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

    namespace oop
    {
        public class avto
        {
            private string number = "";
            private double petrol = 0;
            private double petrol_per_100 = 0;
            private double mileage = 0;
            private int speed = 0;
            private int space = 0;
            private double temp;
            private string temp_trevelled;
            public Random rand = new Random();
            private int passed = 0;
            private double distance = 0;
            string yes_no = "";
            public avto info(avto avto)
            {
                number = "RLB31LB";
                petrol_per_100 = rand.Next(6, 10);
                petrol = rand.Next(20, 60);
                speed = rand.Next(40, 90);
                distance = rand.Next(500, 2000);
                return avto;

            }
            public void infoOut()
            {
                Console.WriteLine("Номер машины: " + number);
                Console.WriteLine("Количество бензина:  " + petrol);
                Console.WriteLine("Затрата на 100 км : " + petrol_per_100);
                Console.WriteLine("Скорость : " + speed);
                Console.WriteLine("Пробег машины: " + mileage);
            }
            private void boost_braking(string temp_trevelled)
            {
                if ((temp_trevelled == "г") || (temp_trevelled == "Г"))
                {
                    speed += 10;
                    petrol_per_100 += 0.5;
                }
                else if ((temp_trevelled == "т") || (temp_trevelled == "Т"))
                {
                    speed -= 10;
                    petrol_per_100 -= 0.5;
                }
            }
            private void zapravka()
            {
                Console.WriteLine("Введите сколько литров нужно заправить (не больше 100): ");
                petrol += int.Parse(Console.ReadLine());
            }
            private bool will_he_get_there()
            {
                double kms = distance / 100;
                bool yes_no = kms > (petrol / petrol_per_100);
                return yes_no;
            }
            private void help(string message)
            {
                if (message == "y")
                {
                    Console.WriteLine("Ваша скорость поднята до 30");
                    speed = 30;
                }
                if (message == "n")
                {
                    Console.WriteLine("Вы не доехали");
                }
            }
            public void drive()
            {

            string y_n = "";
            if (will_he_get_there() == true)
            {
                Console.WriteLine("Вы не сможете доехать до назначенного местаю\n Хотите заправиться(y/n)? ");
                y_n = Console.ReadLine();
            }

            if (y_n == "y")
            {
                zapravka();
            }
            if (y_n == "n")
                Console.WriteLine("Вы не сможете доехать");
            while ((distance > 0) && (petrol > 0))
                {
                    infoOut();
                    Console.WriteLine();
                    Console.WriteLine("Остаток бензина: " + petrol);
                    Console.WriteLine("Скорость: " + speed);
                    Console.WriteLine("Нужно проехать: " + distance);
                    Console.WriteLine("Пробег: " + mileage);
                    distance -= speed;
                    space += speed;
                    temp += speed;
                    mileage += speed;
                    if (speed <= 0)
                    {
                        Console.WriteLine("Скорось опустилась до нуля. ");
                        speed = 0;
                    }
                    if (speed == 0)
                    {
                        Console.WriteLine("Поднять скорость до 30? (y/n)");
                        string mesage = Console.ReadLine();
                        help(mesage);
                    }
                    if (temp >= 200)
                    {
                        Console.WriteLine("Хотите разогнаться или затормозить?(г/т)");
                        temp_trevelled = Console.ReadLine();
                        boost_braking(temp_trevelled);
                        temp = 0;
                    }
                    if (space >= 100)
                    {
                        petrol -= petrol_per_100;

                        space = 0;

                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                    if((distance>=0 )&&(petrol <=0))
                    {
                        if (will_he_get_there() == true)
                        {
                            Console.WriteLine("Вы не сможете доехать до назначенного местаю\n Хотите заправиться(y/n)? ");
                             yes_no= Console.ReadLine();
                        }

                        if (yes_no == "y")
                        {
                            zapravka();
                        }
                        if (yes_no == "n")
                            Console.WriteLine("Вы не сможете доехать");
                    }
                    if ((distance == 0) || (petrol == 0))
                    {
                        Console.WriteLine("Остаток бензина: " + ostatok(petrol));
                    }
                    if (distance <= 0)
                    {
                        Console.WriteLine("Вы доехали.");
                    }
                    else if ((distance > 0) && (petrol <= 0))
                    {
                        Console.WriteLine("Вы не доехали.");
                    }
                }


            }
            private double ostatok(double perol)
            {
                Console.WriteLine(perol);
                return perol;
            }

        }

    }


