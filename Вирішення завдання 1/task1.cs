using System;
using System.IO;
using System.Text;

namespace Mp_task_1
{
     class Program
    {
		static void Main(string[] args)
		{
			string[] unnecessary_words ={"about", "above", "after", "at","between",
				"for", "from", "in", "in front of", "inside", "in spite of", "instead of", "into",
				"like", "near", "of", "off", "on", "onto", "out", "outside", "over", "past", "regarding",
				"to", "toward", "under", "underneath", "until", "up",
				"upon", "up to", "with", "it", "is", "are", "am", "the", "a", "an", "this", "that", "those", "theese"};

			string[] rows;
			using (StreamReader file = new StreamReader("Task1.txt"))
			{
				int counter = 0;
				string row;
			while1:
				if ((row = file.ReadLine()) != null)
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
				if ((row = file.ReadLine()) != null)
				{
					rows[counter] = row;
					counter++;
					goto while2;
				}
				file.Close();
			}

			string[] unwritten_word = new string[0]; 
			int[] NumberOfEachUnique = new int[0]; 

			int ii = 0;
		for_1:
			string[] tmp = rows[ii].Split(" ");
			if (tmp[0] != "")
			{
				int j1 = 0;
			for_2:
				bool FoundCase = false;
				bool unnecessary_word = false;
				int tolowit = 0;
				byte[] asciiBytes1 = Encoding.ASCII.GetBytes(tmp[j1]);
			for_Tolow:
				if (tmp[j1][tolowit] >= 65 && tmp[j1][tolowit] <= 90)
				{
					asciiBytes1[tolowit] += 32;


				}
				tolowit++;
				if (tolowit < tmp[j1].Length)
				{
					goto for_Tolow;
				}
				int l = 0;
				string word = Encoding.ASCII.GetString(asciiBytes1);
			for_3:
				if (unnecessary_words[l] == word) 
				{
					unnecessary_word = true;
				}
				l++;
				if (l < unnecessary_words.Length)
				{
					goto for_3;
				}
				if (!unnecessary_word) 
				{
					int k = 0;
				for_4:
					if (unwritten_word.Length != 0)
					{
						if (unwritten_word[k] == word) 
						{
							NumberOfEachUnique[k]++;
							FoundCase = true;
							goto mark;
						}
					}
					k++;
					if (k < unwritten_word.Length)
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

						int[] tmpUniqueWordsCount = new int[NumberOfEachUnique.Length];
						int p2 = 0;
					for_7:
						if (tmpUniqueWordsCount.Length != 0)
						{
							tmpUniqueWordsCount[p2] = NumberOfEachUnique[p2];
						}
						p2++;
						if (p2 < tmpUniqueWordsCount.Length)
						{
							goto for_7;
						}
						NumberOfEachUnique = new int[NumberOfEachUnique.Length + 1];
						int o2 = 0;
					for_8:

						if (tmpUniqueWordsCount.Length != 0)
						{
							NumberOfEachUnique[o2] = tmpUniqueWordsCount[o2];
						}
						o2++;
						if (o2 < tmpUniqueWordsCount.Length)
						{
							goto for_8;
						}


						unwritten_word[unwritten_word.Length - 1] = word;
						NumberOfEachUnique[NumberOfEachUnique.Length - 1] = 1;
					}
				}
				j1++;
				if (j1 < tmp.Length)
				{
					goto for_2;
				}
			}
			ii++;
			if (ii < rows.Length)
			{
				goto for_1;
			}
			int i2 = 0;
		for_9:
			int j2 = NumberOfEachUnique.Length - 1;
		for_10:
			if (NumberOfEachUnique[j2] > NumberOfEachUnique[j2 - 1])
			{
				int temporary__ = NumberOfEachUnique[j2 - 1];
				NumberOfEachUnique[j2 - 1] = NumberOfEachUnique[j2];
				NumberOfEachUnique[j2] = temporary__;

				string temporary_ = unwritten_word[j2 - 1];
				unwritten_word[j2 - 1] = unwritten_word[j2];
				unwritten_word[j2] = temporary_;
			}
			j2--;
			if (j2 > i2)
			{
				goto for_10;
			}
			i2++;
			if (i2 < NumberOfEachUnique.Length)
			{
				goto for_9;
			}
			int iter = 0;
			if (unwritten_word.Length >= 25)
				iter = 25;
			else iter = unwritten_word.Length;
			int i3 = 0;
			for_11:
				Console.WriteLine(unwritten_word[i3].ToString() + " - " + NumberOfEachUnique[i3].ToString());
				i3++;
				if(i3 < iter)
                {
					goto for_11;
                }
			
		}
	}
}
