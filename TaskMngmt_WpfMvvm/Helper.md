------------------------------------------------------------------------------------------------------------
1. Command
Die abgeleitete Klasse von ICommand steht im Namespace Command mit dem Namen RelayCommand zur Verfügung


------------------------------------------------------------------------------------------------------------
2. OnPropertyChanged

protected void OnPropertyChanged(string propertyName)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}


------------------------------------------------------------------------------------------------------------
3. API Client (Abruf einer TaskItem Liste)

static HttpClient client = new HttpClient();
string path = "https://localhost:<PORT>/api/TaskItems";

HttpResponseMessage response = client.GetAsync(path).Result;
if (response.IsSuccessStatusCode)
{
    string data = response.Content.ReadAsStringAsync().Result;
    return JsonConvert.DeserializeObject<ObservableCollection<TaskItem>>(data);
}