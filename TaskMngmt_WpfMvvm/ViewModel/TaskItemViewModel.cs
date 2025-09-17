using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskMngmt_WpfMvvm.Command;
using TaskMngmt_WpfMvvm.Model;
using Newtonsoft.Json;

namespace TaskMngmt_WpfMvvm.ViewModel
{
    public class TaskItemViewModel : INotifyPropertyChanged
    {
        static HttpClient client = new HttpClient();
        string path = "https://localhost:7126/api/TaskItems";


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ////////////////////////////////////////////////////////////////////////


        private ObservableCollection<TaskItem> _taskItems;

        public ObservableCollection<TaskItem> TaskItems
        {
            get => _taskItems;
            set
            {
                _taskItems = value;
                OnPropertyChanged(nameof(TaskItems));
            }
        }

        public TaskItem SelectedTaskItem { get; set; }

        private TaskItem _newTaskItem;


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public TaskItem NewTaskItem
        {
            get => _newTaskItem;
            set { _newTaskItem = value; OnPropertyChanged(nameof(NewTaskItem)); }
        }

        public TaskItemViewModel()
        {
            TaskItems = GetTaskItems();

            NewTaskItem = new TaskItem();

            AddCommand = new RelayCommand(AddTaskItemAsync);
            DeleteCommand = new RelayCommand(DeleteItem, CanDelete);
        }

        // Commands
        private async void AddTaskItemAsync(object obj)
        {
            if (NewTaskItem is null)
            {
                MessageBox.Show("keine Daten zum speichern", "No Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var jsonData = JsonConvert.SerializeObject(NewTaskItem);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                TaskItems = GetTaskItems();

                NewTaskItem = new TaskItem();

                MessageBox.Show("Daten hinzugefügt", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Element konnte nicht gespeichert werden!",
                                        "Fehler",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
            }  
            
        }

        private bool CanDelete(object obj) => SelectedTaskItem != null;

        private void DeleteItem(object obj)
        {
            if (SelectedTaskItem != null)
            {
                HttpResponseMessage response = client.DeleteAsync(path + "/" + SelectedTaskItem.Id).Result;

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Element konnte nicht gelöscht werden!",
                                        "Fehler",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    return;
                }
                else
                {
                    TaskItems.Remove(SelectedTaskItem);
                    //TaskItems = GetTaskItems();
                    SelectedTaskItem = null;
                }
            }
        }

        private ObservableCollection<TaskItem> GetTaskItems()
        {
            TaskItems = new ObservableCollection<TaskItem>();

            HttpResponseMessage response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<ObservableCollection<TaskItem>>(data);
            }
            return TaskItems;
        }


    }
}
