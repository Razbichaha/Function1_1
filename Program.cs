using System;

namespace Function1_1
{
    class Program
    {  
        static void Main(string[] args)
        {
            string[,] fullName = { { " ","Фамилия","Имя","Отчество" },{"1","dgghfhyj","jvgjfvj","cghjj" }, { "2", "ввввв", "jvgjfаvj", "cghыыjj" }, 
                                    { "3", "вв", "jvgjfаvj", "cghыыjj" },{ "4", "jj", "jvgjfаvj", "cghыыjj" } };
            string[] positions = { "должность","dfgdth", "dfgdth", "dfgdth", "dfgdth" };

            bool isContinueProgram = true;
            outputMesadge();

            while (isContinueProgram)
            {
               
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "добавить":

                        fullName = addDossierFullName(fullName);
                        positions = addDossierPosition(positions);
                        Console.Clear();
                        showDossier(fullName, positions);

                        break;
                    case "вывести":

                        showDossier(fullName, positions);

                        break;
                    case "удалить":

                        Console.Write("Для удаления работника введите фамилию - ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine();

                        positions = deleteDossier(fullName, positions, lastName);
                        fullName = deleteDossier(fullName, lastName);
                        showDossier(fullName, positions);

                        break;
                    case "найти":
                        Console.Write("Для поиска работника введите фамилию - ");
                        lastName = Console.ReadLine();
                        searchInDossier(fullName, positions, lastName);

                        break;
                    case "закрыть":
                        Console.Clear();
                        isContinueProgram = false;

                        break;
                    default:
                        Console.Clear();
                        outputMesadge();
                        showDossier(fullName, positions);
                        break;
                }
            }
        }

        static void searchInDossier(string[,] fullName, string[] positions, string lastName)
        {
            string tempString = "";

            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                
                if (fullName[i, 1] == lastName)
                {

                    for (int j = 0; j < fullName.GetLength(1); j++) 
                    {
                    tempString += fullName[i, j] + "-";
                    }
                    tempString += ("-" + positions[i]);
                }
            }
            Console.WriteLine(tempString);
        }
        static void outputMesadge()
        {
            Console.WriteLine("Для вывода данных работника наберите       - вывести");
            Console.WriteLine("Для добавления даных работника наберите    - добавить");
            Console.WriteLine("Удаления работника из базы данных наберите - удалить");
            Console.WriteLine("Для закрыти программы наберите             - закрыть");
            Console.WriteLine("Для поиска работника наберите              - найти");

        }
        static void showDossier(string[,] fullName, string[] positions)
        {

            for(int i=0;i<fullName.GetLength(0);i++)
            {
                string tempString = "";

                for(int j=0;j<fullName.GetLength(1);j++)
                {
                    tempString += fullName[i,j] + "-";
                }

                if (i == 0)
                {
                   Console.WriteLine("-" + tempString + positions[i]);
                }
                else
                {
                    Console.WriteLine("|" + tempString + positions[i]);
                }
            }
        }
        static string[,] addDossierFullName(string[,] fullName)
        {
            string[,] tempStringFullName = new string[fullName.GetLength(0)+1,4];
            
            for(int i=0;i<fullName.GetLength(0); i++)
            {
                for(int j=0;j<fullName.GetLength(1);j++)
                {
                    tempStringFullName[i, j] = fullName[i, j];
                }
            }

            tempStringFullName[fullName.GetLength(0), 0] = (int.Parse(fullName[fullName.GetLength(0) - 1, 0]) + 1).ToString();

            Console.Write("Введите фамилию - ");
            tempStringFullName[fullName.GetLength(0), 1] = Console.ReadLine();
            Console.Write("Введите имя - ");
            tempStringFullName[fullName.GetLength(0), 2] = Console.ReadLine();
            Console.Write("Введите отчество - ");
            tempStringFullName[fullName.GetLength(0), 3] = Console.ReadLine();

            return tempStringFullName;
        }
        static string[] addDossierPosition(string[] positions)
        {

            Console.Write("Введите должность - ");
            string position = Console.ReadLine();
            Console.WriteLine();

            string[] tempStringPosition = new string[positions.Length + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                tempStringPosition[i] = positions[i];
            }

            tempStringPosition[positions.Length] = position;

            return tempStringPosition;
        }
        static string[,] deleteDossier(string[,] fullName, string lastName)
        {
            string[,] temp = new string[fullName.GetLength(0)-1, fullName.GetLength(1)];

            int counterTemp = 0;
            for (int i = 0; i <= temp.GetLength(0); i++)
            {

                if (fullName[i, 1] != lastName) 
                {
                    for (int j = 0; j < temp.GetLength(1); j++)
                    {
                        temp[counterTemp, j] = fullName[i, j];
                    }
                    counterTemp++;
                }
                
            }
            return temp;
        }
        static string[] deleteDossier(string[,] fullName, string[] positions, string lastName)
        {

            int counterTemp = 0;
            string[] temp = new string[positions.Length - 1];

            for (int i = 0; i < temp.Length; i++)
            {
                if (fullName[i, 1] != lastName)
                {
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[counterTemp] = positions[i];
                    }
                    counterTemp++;
                }
            }
            return temp;
        }
    }
}
