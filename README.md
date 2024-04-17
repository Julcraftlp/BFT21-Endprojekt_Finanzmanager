# FiMa Alpha 2

### Datenstruktur (Aktuelle Nutzung)

```mermaid
classDiagram 
User "1" *--> "*" Account

User : +int Id
User : +string FirstName
User : +string LastName
User : +string Username = null!
User : +string Password = null!
User : +DateTime LockedUntil
User : +ICollection<Account>? Accounts

Account : +int Id
Account : +User User = null!
Account : +string Name = null!
Account : +double Betrag = 0.0
Account : +string TF1 = null!
```

### Datenstruktur (Aktueller aufbau in sicht auf zukünftige funktion)

```mermaid
classDiagram 
User "1" *--> "*" Account
User "1" ..> "1"Laendercode

User : +int Id
User : +string FirstName
User : +string LastName
User : +string Username = null!
User : +string Password = null!
User : +DateTime LockedUntil
User : +ICollection<Invoice>? Buchungen
User : +ICollection<Account>? Accounts

Account : +int Id
Account : +User User = null!
Account : +string Name = null!
Account : +double Betrag = 0.0
Account : +bool KontoTyp
Account : +string TF1 = null!
Account : +Laendercode? Laendercode
Account : +int Kontrollsumme
Account : +BLZ? BankLeitZahl
Account : +int KontoNummer
Account : +DateOnly? Gülitgkeit
```
