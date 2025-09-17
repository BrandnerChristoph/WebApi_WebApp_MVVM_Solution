# Solution zum Wiederholungsprojekt des 4. Jahrgangs
Das Projekt stellt eine Lösung für ein einfaches Aufgabenmanagement bereit bei dem die zentrale Datenpersistenz in der WebAPI abgehandelt wird. Diese stellt mit den benötigten Endpoints die Informationen zur Verfügung. 
Darüber hinaus steht eine WebApp bereit um die Daten in einem Browser anzuzugeigen. Außerdem besteht die Möglichkeit mit Hilfe einer Deskotp Anwendung (C# WPF mit MVVM) die Datendarstellung auch vorzunehmen. Die beiden Applikationen für die Endnutzer kommunizieren mit Hilfe von REST API Calls mit der WebAPI und stellen die Daten dar.

In der Projektmappe sind drei Projekte enthalten, die gemeinsam ein lauffähiges System mit unterschiedlichen Aufgaben bereitstellen
- [WebAPI](https://github.com/BrandnerChristoph/WebApi_WebApp_MVVM_Solution/tree/main/TaskMngmt_WebApi)
- [WebApp](https://github.com/BrandnerChristoph/WebApi_WebApp_MVVM_Solution/tree/main/TaskMngmt_WebApp)
- [WPF MVVM](https://github.com/BrandnerChristoph/WebApi_WebApp_MVVM_Solution/tree/main/TaskMngmt_WpfMvvm)

## Projektstart 
Bei der Konfiguration des Projektstart ist definiert, dass alle drei Projekt gestartet werden, damit auch die WebApp und das WPF (MVVM) Projekt auf die Web API zugreifen können. 
Der Starteigenschaften können in den Eigenschaften der Projektmappe hinterlegt werden und sind wie nachstehend angegeben definiert.
<img width="2399" height="1241" alt="image" src="https://github.com/user-attachments/assets/2e15f067-b5d7-4104-9984-1e915818d8e0" />


## Initialisierungsdaten laden
Um die Applikation beim Start bereits mit Daten in der InMemory Datenbank zu versorgen werden Initialiiserungsdaten aus der Klasse [InitData.cs](https://github.com/BrandnerChristoph/WebApi_WebApp_MVVM_Solution/blob/main/TaskMngmt_WebApi/Data/InitData.cs)

```csharp
// add init data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    InitData.Initialize(services);
}
```
