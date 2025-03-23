📌 Czym jest ten interfejs?
Jest to generyczny interfejs repozytorium, który definiuje zestaw metod do operacji na danych w bazie danych. Służy do zarządzania encjami w aplikacjach wykorzystujących Entity Framework lub inne rozwiązania ORM (Object-Relational Mapping).

📌 Jakie metody zawiera?
Get(...) – Pobiera listę obiektów spełniających określone kryteria.

Query(...) – Zwraca zapytanie (IQueryable<TEntity>) do dalszej obróbki (np. filtrowania, sortowania).

GetById(...) – Pobiera pojedynczą encję na podstawie jej klucza głównego (ID).

GetFirstOrDefault(...) – Pobiera pierwszą pasującą encję lub zwraca null, jeśli nie znaleziono.

Insert(...) – Dodaje nową encję do bazy danych.

Update(...) – Aktualizuje istniejącą encję.

Delete(...) – Usuwa encję na podstawie jej ID.

📌 Główne zalety tego podejścia
✅ Reużywalność – Można go używać dla różnych typów encji bez duplikowania kodu.
✅ Encapsulacja – Ukrywa szczegóły dostępu do bazy danych.
✅ Testowalność – Ułatwia testowanie kodu dzięki abstrakcji warstwy dostępu do danych.

📌 Gdzie się tego używa?
W architekturze warstwowej (np. separacja logiki biznesowej od dostępu do danych).

W aplikacjach ASP.NET Core z Entity Framework.

W projektach korzystających z Unit of Work do zarządzania transakcjami.
