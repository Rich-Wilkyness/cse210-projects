using System;

class RandomIndex
{
    private int index;
    private List<int> currentIndexes = new List<int>();
    // private List<int> previousIndexes = new List<int>();


    public void AddRandomIndex(int scriptureLength)
    {
        bool keepGoing = true;
        while (keepGoing == true)
        {
            var random = new Random();

            index = random.Next(scriptureLength);

            keepGoing = false;
            foreach (int i in currentIndexes)
            {
                if (i == index)
                {
                    keepGoing = true;
                }
            }
        }
        currentIndexes.Add(index);
    }
    public List<int> GetCurrentIndexes()
    {
        return currentIndexes;
    }
    // public List<int> GetPreviousIndexes()
    // {
    //     return previousIndexes;
    // }
    // public void UpdatePreviousIndex()
    // {
    //     previousIndexes = currentIndexes;
    // }
}