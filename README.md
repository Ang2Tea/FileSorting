# FileSorting
## Оглавление 
1. [Цель проекта](#ProjectGoals)
2. [Элементы библиотеки](#LibraryElements)
    + [Класс FilesSorting](#FilesSorting)
    + [Интерфейс ISortingConfig](#ISortingConfig)
    + [Класс StandartConfig](#StandartConfig)
    + [Перечисление ChangeNameState](#ChangeNameState)
    + [Интерфейс ILogger](#ILogger)
    + [Класс DebugLogger](#DebugLogger)
    + [Класс NameTakenException](#NameTakenException)
3. [Элементы консольного приложения](#ConsoleElements)
    + [Класс ConsoleLogger](#ConsoleLogger)
    + [Класс ConfigParser\<T\>](#ConfigParser)
    + [Класс NullConfigException](#NullConfigException)

## Цели проекта <a name="ProjectGoals"></a>
Предоставить пользователю

* Встраиваемую библиотеку для использования в своих проектах;
* Настраиваемый процесс сортировки;
* Простое приложения для сортировки файлов с настройкой через json файл.

## Элементы библиотеки <a name="LibraryElements"></a>

### Класс `FilesSorting` <a name="FilesSorting"></a>
Главный класс библиотеки. Находтися в пространсве именн имен `FileSorting.Core`

#### Конструкторы 
Имеет 2 конструктор

* `FilesSorting(ISortingConfig config, ILogger log)`  
**config** -  класс конфигурации реалезующий интерфейс `ISortingConfig`,  
**log** - класс для вывода информации хода работы реалезующий интерфейс `ILogger`
* `FilesSorting(ISortingConfig config)`  
**config** -  класс конфигурации реалезующий интерфейс `ISortingConfig`,

#### Методы
* `void StartMovingFile()`  
Начитанает сортировку файлов

### Интерфейс `ISortingConfig` <a name="ISortingConfig"></a>
Нужен для создания различный реалезаций своих конфигурации. Находтися в пространсве имен `FileSorting.Core.Configs`

#### Свойства

* `string SortingPath`  
Содержит в себе путь к папке в которой нужно отсортировать
* `ChangeNameState ChangeState`
Сожержит в себе состояние которое будет реалезоваться при файлы в папку с занятым именем

### Класс `StandartConfig` <a name="StandartConfig"></a>
Реалезация интерфейса `ISortingConfig`, имеет настройку свойств с помощью атрибута `JsonPropertyName` и конструктор которые принимают все пораметры для заполнения свойств `ISortingConfig`. Находтися в пространсве имен `FileSorting.Core.Configs`

### Перечисление `ChangeNameState` <a name="ChangeNameState"></a> 
Перечисления состояний перемещения файлы. Отчет свойсв начинается с 1. Находтися в пространсве имен `FileSorting.Core.Configs`

* `Exception`
* `Change`
* `Ignoring`

### Интерфейс ILogger <a name="ILogger"></a>
Нужен для создания различный реалезаций отоброжения хода работы. Находтися в пространсве имен `FileSorting.Logging`

#### Методы

* `void InfoLog(string message)`  
**message** - строка которая будет выведена в вашей реалезации `ILogger`

* `void ErrorLog(string message)`  
**message** - строка которая будет выведена в вашей реалезации `ILogger`

### Класс DebugLogger <a name="DebugLogger"></a>
Реалезация интерфейса ILogger, выводит полученные сообщения с помощью статического класса `Debug`. Находтися в пространсве имен `FileSorting.Logging.SpecificLogger`

### Класс NameTakenException <a name="NameTakenException"></a>
Класс ошибки вызываемой при `ChangeNameState.Exception` и уже имеющемся файле с таким именем в папке. Находтися в пространсве имен `FileSorting.Core.Exceptions`

#### Конструкторы 
* `NameTakenException(FileInfo file, string? message)`  
**file** - файл в котором была вызвана ошибка  
**message** - текст ошибки
* `NameTakenException(FileInfo file)`  
**file** - файл в котором была вызвана ошибка

#### Свойства 
* `FileInfo File`  
Содержит в себе файл в котором произошла ошибка

## Элементы библиотеки <a name="ConsoleElements"></a>

### Класс `ConsoleLogger` <a name="ConsoleLogger"></a>
Явяется классом реалезующий интерфейс `ILogger` из библиотеки, нужен для предаставления вывода информации хода приложения в консоль. Находтися в пространсве именн имен `FileSortingConsole`

### Класс `ConfigParser<T>` <a name="ConfigParser"></a>
Класс позволяющий распарсить json по указанному пути. `T` обощение ограниченое по интерфейсу `ISortingConfig`

#### Конструктор  
* `ConfigParser(string configPath)`  
**configPath** - строка к пути нахождения json файла
* `ConfigParser()`  
Пустой конструктор задающий строку как "config.json"

#### Методы 
* `ISortingConfig Parse()`  
Метод читающий файл по заданому пути и переводит его в обьект `T` реалезующий интерфейс `ISortingConfig`
* `static ISortingConfig Parse<TConfig>(string configPath)`  
Метод читающий файл по заданому пути и переводит его в обьект `TConfig` реалезующий интерфейс `ISortingConfig`  
**configPath** - путь к json файлу  

### Класс `NullConfigException` <a name="NullConfigException"></a>
Класс вызываемый если при парсенге конфигурации вернулся null