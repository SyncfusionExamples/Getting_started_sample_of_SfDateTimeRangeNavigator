using System.Collections.ObjectModel;

namespace DateTimeRangeNavigator
{
    public class ViewModel
    {
        private Random randomNumber;
        public ObservableCollection<DataModel> DataSource { get; set; }

        public ViewModel() 
        {
            randomNumber = new Random();
            DataSource = GenerateData(182);
        }

        public ObservableCollection<DataModel> GenerateData(int dataCount)
        {
            ObservableCollection<DataModel> data = new();
            DateTime date = new DateTime(2010, 1, 1);
            double value = 100;

            for (int j = 0; j < dataCount; j++)
            {
                data.Add(new DataModel { Date = date, Metric = value });

                if (randomNumber.NextDouble() > 0.5)
                    value += randomNumber.NextDouble();
                else
                    value -= randomNumber.NextDouble();

                value = Math.Min(value, 134);
                date = date.AddDays(1);
            }

            return data;
        }
    }
}
