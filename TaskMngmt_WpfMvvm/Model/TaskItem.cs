using System.ComponentModel;

namespace TaskMngmt_WpfMvvm.Model
{
    public class TaskItem : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int _isFinished = 0;
        public int IsFinished
        {
            get => _isFinished;
            set
            {
                _isFinished = value;
                OnPropertyChanged(nameof(IsFinished));
            }
        }
        
        public DateTime CreatedAt { get; set; }

        public TaskItem()
        {
            this.CreatedAt = DateTime.Now;
        }

        // INotifyPropertyChanged START
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // INotifyPropertyChanged ENDE
    }
}
