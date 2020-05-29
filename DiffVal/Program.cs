using DiffVal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;

namespace DiffVal
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> display = Console.WriteLine;
            string file1 = "AIFE-Chorus-Pro-Annuaire_06042020.csv";
            string file2 = "AIFE-Chorus-Pro-Annuaire_20200525-services-only.csv";
            char separator = ';';
            var listeTable = new List<ChorusServicesTable>();
            var listeWeb = new List<ChorusServicesWeb>();
            bool hasHeader = true;
            int indexReader = 0;
            using (StreamReader streamReader = new StreamReader(file1))
            {
                while (!streamReader.EndOfStream)
                {
                    if (indexReader == 0 && hasHeader)
                    {
                        string line2 = streamReader.ReadLine();
                        indexReader++;
                        continue;
                    }

                    string line = streamReader.ReadLine();
                    indexReader++;
                    var lineArray = line.Split(separator);
                    bool gestionEGMT = lineArray[5].ToLower() == "true" ? true : false;
                    bool serviceActif = lineArray[6].ToLower() == "true" ? true : false;

                    var oneChorusService = new ChorusServicesTable(
                        lineArray[0],
                        lineArray[1],
                        lineArray[2],
                        lineArray[3],
                        lineArray[4],
                        gestionEGMT,
                        serviceActif,
                        lineArray[7],
                        lineArray[8],
                        lineArray[9],
                        lineArray[10],
                        lineArray[11],
                        lineArray[12],
                        lineArray[13],
                        lineArray[14],
                        lineArray[15]
                        );

                    listeTable.Add(oneChorusService);
                }
            }

            indexReader = 0;
            hasHeader = true;
            using (StreamReader streamReader2 = new StreamReader(file2))
            {
                while (!streamReader2.EndOfStream)
                {
                    if (indexReader == 0 && hasHeader)
                    {
                        string line2 = streamReader2.ReadLine();
                        indexReader++;
                        continue;
                    }

                    string line = streamReader2.ReadLine();
                    indexReader++;
                    var lineArray = line.Split(separator);
                    bool gestionEGMT = lineArray[4].ToLower() == "true" ? true : false;
                    bool serviceActif = lineArray[5].ToLower() == "true" ? true : false;

                    var oneChorusService = new ChorusServicesWeb(
                        lineArray[0],
                        lineArray[1],
                        lineArray[2],
                        lineArray[3],
                        gestionEGMT,
                        serviceActif,
                        lineArray[6],
                        lineArray[7],
                        lineArray[8],
                        lineArray[9],
                        lineArray[10],
                        lineArray[11],
                        lineArray[12],
                        lineArray[13],
                        lineArray[14]
                        );

                    listeWeb.Add(oneChorusService);
                }
            }

            var listeDiff = new List<ChorusServicesWeb>();
            var diffIdentifiant = listeWeb.Where(p => !listeTable.Any(p2 => p2.Identifiant == p.Identifiant));
            var diffIdentifiantAndCode = listeWeb.Where(p => !listeTable.Any(p2 => p2.Identifiant == p.Identifiant && p2.Code == p.Code));
            var lesIdentifiants = diffIdentifiant.ToList();
            var lesIdentifiantsEtLesCodes = diffIdentifiantAndCode.ToList();
            display($"diff identifiants : {lesIdentifiants.Count}"); // 553
            display($"diff identifiants et les codes : {lesIdentifiantsEtLesCodes.Count}"); // 848

            using (StreamWriter sw = new StreamWriter("identifiants.csv"))
            {
                foreach (var item in lesIdentifiants)
                {
                    string test = item.ToWebCSVString(separator.ToString());
                    sw.WriteLine(item.ToWebCSVString(separator.ToString()));
                }
            }

            using (StreamWriter sw = new StreamWriter("lesIdentifiantsEtLesCodes.csv"))
            {
                foreach (var item in lesIdentifiantsEtLesCodes)
                {
                    string test = item.ToWebCSVString(separator.ToString());
                    sw.WriteLine(item.ToWebCSVString(separator.ToString()));
                }
            }

            display("Press any key to exit:");
            Console.ReadKey();
        }

    }
}
