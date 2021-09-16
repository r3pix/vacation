namespace ItmCode.Common.Resources
{
    public static class ValidationResource
    {
        public const string BusinessObjectsDoesNotBelongToClient = "Nie wszystkie obiekty biznesowe należą do klienta";
        public const string CannotSetOrderType = "Nie można zmienić statusu z '{Current}' na '{Requested}'";
        public const string CompanyEmployeeCannotBeAssigned = "Nie można przypisać tego pracownika do zlecenia";
        public const string CompanyEmployeeIsNotAssigned = "Pracownik nie jest przypisany do zlecenia";
        public const string CompanyIsNotOfType = "{EntityName} od ID {Value} nie jest typu {ExpectedValue}";
        public const string ContractDoesNotBelongToClient = "Kontrakt nie należy do podanego klienta";
        public const string EmailExist = "Email już został zarejestrowany";
        public const string EmailNotExist = "Email nie został zarejestrowany";
        public const string EmailsExist = "Adresy email:\"{InvalidEmails}\" są już zarejestrowane";
        public const string EntitiesExist = "Rekordy o podanych id istnieją dla {EntityName}";
        public const string EntitiesNotExist = "Nie wszystkie podane id istnieją dla {EntityName}";
        public const string FieldIsNotUnique = "Wartość {PropertyName} już istnieje";
        public const string FileNotExist = "Plik nie istnieje lub został usunięty";
        public const string IdCardNumberInvalid = "Nieprawidłowa seria/numer dowodu";
        public const string IdExist = "Rekord o ID {Value} już istnieje dla {EntityName}";
        public const string IngredientIsAssignedToRecipeCost = "Koszty: \" {Value} \" zależą od tego składnika";
        public const string NotFoundById = "Nie znaleziono rekordu o ID {Value} dla {EntityName}";
        public const string OrderByNotInList = "Wartość {Value} dla Order By nie zawiera się dozwolonym zakresie";
        public const string PasswordIncorrect = "Podane hasło jest nieprawidłowe";
        public const string PeselIncorrect = "Niepoprawna suma kontrolna numeru PESEL";
        public const string RecipeCostIsAssignedToItem = "Produkt {Value} zależy od tego kosztu";
        public const string RegonIncorrect = "Niepoprawna suma kontrolna numeru REGON";
        public const string TaxNumberIncorrect = "Niepoprawna suma kontrolna numeru NIP";
        public const string UserForbidden = "Użytkownik nie ma dostępu do zasobu";
        public const string UserNotExists = "Użytkownik nie istnieje";
        public const string UserNotHavePermission = "Użytkownik nie posiada odpowiednich uprawnień";
        public const string OrderTypeExists = "Podany typ już istnieje";
        public const string VersionNumberExists = "Podana wersja już istnieje";
        public const string OrderStatusExists = "Podany status już istnieje";
        public const string CannotDeleteOrderStatus = "Nie można usunąć statusu o id {Value}";
        public const string CustomerWithNipExist = "Klient o podanym numerze NIP istnieje już w systemie";
        public const string WeightNotFound = "Nie można zmienić statusu, ponieważ nie odnaleziono ważenia dla danej dostawy";
    }
}