// See https://aka.ms/new-console-template for more information

// Przywitanie
// Wybór akcji
/// 1. Stworzenie nowego kandydata
//// A. Wybierz kategorię rekrutacji (pracownik umyslowy, fizyczny, kierowca)
//// B. Wprowadzenie szczegółów (Imię, Nazwisko etc.)
/// 2. Usunięcie danych kandydata
//// A. Wskazanie id lub nazwy kandydata
//// B. Wskazanie usunięcia CV lub całego profilu kandydata
//// C. Usunięcie z listy
/// 3. Sprawdzenie bazy danych kandydatów
//// A. Wskazanie id lub nazwy kandydata
//// B. Wyświetlenie wszystkich informacji zw. z kandydatem wraz z nazwą kategorii
/// 4. Zwrócenie listy kandydatów po zadanym filtrze kategorii
//// A. Wskazanie nazwy lub kategorii
//// B. Wyświetlenie listy

using CVManager;

MenuActionService actionService = new MenuActionService();
actionService = Initialize(actionService);

CandidateService candidateService = new CandidateService();

Console.WriteLine("Welcome to CVManager console app!");

while (true)
{

    Console.WriteLine("Please select the operation:");
    var mainMenu = actionService.GetMenuActionsByMenuName("Main");
    for (int i = 0; i < mainMenu.Count; i++)
    {
        Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
    }

    var operation = Console.ReadKey();

    switch (operation.KeyChar)
    {
        case '1':
            var keyInfo = candidateService.AddNewCandidateView(actionService);
            var candidateId = candidateService.AddNewCandidate(keyInfo.KeyChar);
            break;
        case '2':
            var removeId = candidateService.RemoveCandidateView(actionService);
            candidateService.RemoveCandidate(removeId);
            break;
        case '3':
            var showId = candidateService.ShowCandidateView(actionService);
            candidateService.ShowCandidate(showId);
            break;
        case '4':
            break;
        default:
            Console.WriteLine("Invalid action chosen.");
            break;
    }
}

static MenuActionService Initialize(MenuActionService actionService)
{
    actionService.AddNewAction(1, "Add new candidate", "Main");
    actionService.AddNewAction(2, "Remove candidate", "Main");
    actionService.AddNewAction(3, "Search candidate", "Main");
    actionService.AddNewAction(4, "Show list of candidates", "Main");

    actionService.AddNewAction(1, "Office worker", "AddNewCandidate");
    actionService.AddNewAction(2, "Labourer", "AddNewCandidate");
    actionService.AddNewAction(3, "Driver", "AddNewCandidate");
    return actionService;
}