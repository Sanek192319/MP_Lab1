using System;
using System.IO;
using System.Text;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] unnecessary_words = {"about", "above", "after", "at","between",
				"for", "from", "in", "in front of", "inside", "in spite of", "instead of", "into",
				"like", "near", "of", "off", "on", "onto", "out", "outside", "over", "past", "regarding",
				"to", "toward", "under", "underneath", "until", "up",
				"upon", "up to", "with", "it", "is", "are", "am", "the", "a", "an", "this", "that", "those", "theese"};

			string[] rows;
			using (StreamReader file = new StreamReader("task2.txt"))
			{
				int counter = 0;
				string row;
				while1:
				if((row = file.ReadLine()) != null)
				{
					counter++;
					goto while1;
				}
				rows = new string[counter];
				file.DiscardBufferedData();
				file.BaseStream.Seek(0, SeekOrigin.Begin);
				counter = 0;
				row = "";
				while2:
				if((row = file.ReadLine()) != null)
				{
					rows[counter] = row;
					counter++;
					goto while2;
				}
				file.Close();
			}

			string[] unwritten_word = new string[0]; 
			string[] CountOfUniques = new string[0]; 
			int i1 = 0;
		for_1:
			string[] tmp = rows[i1].Split(" ");
			if (tmp[0]!= "")
			{
				int j1 = 0;
			for_2:
				bool FoundCase = false;
				bool unnecessary_word = false;
				int tolowit = 0;
				byte[] asciiBytes = Encoding.ASCII.GetBytes(tmp[j1]);
			for_Tolow:
				if (tmp[j1][tolowit] >= 65 && tmp[j1][tolowit] <= 90)
				{
					asciiBytes[tolowit] += 32;
				}
				tolowit++;
				if (tolowit < tmp[j1].Length)
				{
					goto for_Tolow;
				}
				int l1 = 0;
				string word = Encoding.ASCII.GetString(asciiBytes);
			for_3:
				if (unnecessary_words[l1] == word) 
				{
					unnecessary_word = true;
				}
				l1++;
				if (l1 < unnecessary_words.Length)
				{
					goto for_3;
				}

				if (!unnecessary_word) 
				{
					int k1 = 0;
				for_4:
					if (unwritten_word.Length != 0)
						if (unwritten_word[k1] == word) 
						{
							int NumberOfPage = i1 / 45 + 1;
							CountOfUniques[k1] += (", " + NumberOfPage.ToString());
							FoundCase = true;
							goto mark;
						}
					k1++;
					if (k1 < unwritten_word.Length)
					{
						goto for_4;
					}
				mark:
					if (!FoundCase) 
					{
						string[] tmpUniqueWords = new string[unwritten_word.Length];
						int p1 = 0;
					for_5:
						if (tmpUniqueWords.Length != 0)
						{
							tmpUniqueWords[p1] = unwritten_word[p1];
						}
						p1++;
						if (p1 < tmpUniqueWords.Length)
						{
							goto for_5;
						}
						unwritten_word = new string[unwritten_word.Length + 1];
						int o1 = 0;
					for_6:
						if (tmpUniqueWords.Length != 0)
						{
							unwritten_word[o1] = tmpUniqueWords[o1];
						}
						o1++;
						if (o1 < tmpUniqueWords.Length)
						{
							goto for_6;
						}

						string[] tmpUniqueWordsCount = new string[CountOfUniques.Length];
						int p2 = 0;
					for_7:
						if (tmpUniqueWordsCount.Length != 0)
						{
							tmpUniqueWordsCount[p2] = CountOfUniques[p2];
						}
						p2++;
						if (p2 < tmpUniqueWordsCount.Length)
						{
							goto for_7;
						}
						CountOfUniques = new string[CountOfUniques.Length + 1];
						int o2 = 0;
					for_8:
						if (tmpUniqueWordsCount.Length != 0)
							CountOfUniques[o2] = tmpUniqueWordsCount[o2];
						o2++;
						if (o2 < tmpUniqueWordsCount.Length)
						{
							goto for_8;
						}

						unwritten_word[unwritten_word.Length - 1] = word;
						int NumberOfPage = i1 / 45 + 1;
						if (CountOfUniques[CountOfUniques.Length - 1] == null)
						{
							CountOfUniques[CountOfUniques.Length - 1] = NumberOfPage.ToString();
						}
						else
						{
							CountOfUniques[CountOfUniques.Length - 1] = ", " + NumberOfPage.ToString();
						}
					}
				}
				j1++;
				if (j1 < tmp.Length)
				{
					goto for_2;
				}
			}
				i1++;
				if(i1<rows.Length)
                {
					goto for_1;
                }
			int i2 = 0;
		for_9:
			int j2 = unwritten_word.Length - 1;
			for_10:
					bool toReplace = false;
					int length = unwritten_word[j2].Length > unwritten_word[j2 - 1].Length ? unwritten_word[j2 - 1].Length : unwritten_word[j2].Length;

					byte[] ByteWord1 = Encoding.ASCII.GetBytes(unwritten_word[j2 - 1]);
					byte[] ByteWord2 = Encoding.ASCII.GetBytes(unwritten_word[j2]);
					for (int o = 0; o < length; o++)
					{
						if (ByteWord1[o] > ByteWord2[o])
						{
							toReplace = true;
							break;
						}
						if (ByteWord1[o] < ByteWord2[o])
						{
							toReplace = false;
							break;
						}
					}
					if (toReplace)
					{
						string s = unwritten_word[j2];
						unwritten_word[j2] = unwritten_word[j2 - 1];
						unwritten_word[j2 - 1] = s;

						string pageInfo = CountOfUniques[j2];
						CountOfUniques[j2] = CountOfUniques[j2 - 1];
						CountOfUniques[j2 - 1] = pageInfo;
					}
				j2--;
				if(j2>i2)
                {
					goto for_10;
                }
			i2++;
			if(i2 < unwritten_word.Length)
            {
				goto for_9;
            }



			int iter = 0;
			if (unwritten_word.Length >= 250)
				iter = 250;
			else iter = unwritten_word.Length;
			int i3 = 0;
			for11:
				if (CountOfUniques[i3].Split(", ").Length <= 100 )
					Console.WriteLine(unwritten_word[i3].ToString() + " - " + CountOfUniques[i3].ToString());
				i3++;
				if(i3<iter)
                {
					goto for11;
                }
		}
    }
}
