Projekt **E-commerce** skupia się na złożonych wymaganiach biznesowych. Do działania w pełni funkcjonalnej strony internetowej należy w **przeanalizować**, opracować różne **przypadki użycia** i sporządzić własny **model biznesowy oraz lejek sprzedażowy**. 

Zdefiniowanie wcześniej wymienionych założeń pozwoli lepiej zrozumieć **potrzeby oraz perspektywę użytkownika**, by następnie przygotować w pełni funkcjonalny system informatyczny, umożliwiający uzyskanie jak najlepszych wyników **sprzedaży oraz doświadczeń użytkownika**.

![](https://landing.moqups.com/img/templates/wireframes/ecommerce-low-fidelity-wireframe.png)

Mówi się, że każda czynność jaką wykonuje użytkownik powinna się zamykać maksymalnie do **trzech kliknięć**. W tym celu, by zaprojektować w pełni działające ekrany użytkownika zdecydowano się na zastosowanie **heurystyki Nielsena**, pozwalający przeprowadzić w sposób indywidualny walidację określonego przepływu procesu użytkownika.

**Branża**
Do tego projektu wybrano przemysł technologiczny, ze względu na uniwersalne zapotrzebowanie na rynku i dostosowanie do potrzeb dla każdego konsumenta niezależnie od wysokości budżetu, który posiada.
## Cel systemu

Celem systemu jest **przetestowanie technologi ASP.NET Core MVC** w praktyce i uzyskanie wniosków potrzebnych do analizy, a także **zdobycie nowego doświadczenia**.
## Wymagania funkcjonalne

Aplikacja do sprzedaży **usług** bądź **urządzeń** posiada zestaw podstawowych funkcji, które z perspektywy potrzeb biznesowych należy **zaimplementować**.

- Logowanie i rejestracja użytkownika,
- Rejestracja karty płatniczej i przypisywanie na konto wraz z szyfrowaniem karty płatniczej, należy uwzględnić walidację co do unikalności numeru konta bankowego,
- Edytowanie danych personalnych i kontaktowych użytkownika,
- Generowanie faktury po dokonaniu transakcji i zatwierdzeniu płatności przez system,
- Resetowanie hasła,
- Historia zamówień,
- Zarządzanie zamówieniami,
- Wprowadzanie kodów rabatowych, produktów i usług poprzez dedykowany do tej roli panel administracyjny,
- Dane kontaktowe,
- Stan magazynowy produktu wraz z ceną i szczegółami,
- Inteligentne wyniki wyszukiwania oraz rozbudowane narzędzie do filtrowania wyników,
- Koszyk oraz wishlista, wyświetlająca stosowne komunikaty,

## Wymagania niefunkcjonalne

Znając potrzeby rynkowe oraz biznesowe, wskazano następujący stack technologiczny:

- C#, Microsoft Entity Framework, .NET 8, ASP.NET Core MVC,
- Docker do konteneryzacji systemu,

## Diagramy

Aby logika biznesowa **spełniała podstawy potrzeb rynkowych**, konieczne jest wyrażenie różnych przypadków użycia na diagramie. Poniżej ujęto pełny zestaw diagramów, które odpowiednio wizualizują wymagania funkcjonalne.

**Logowanie i rejestracja**
![[Logowanie i rejestracja.png]]

**Rejestracja karty platniczej**
![[Rejestracja karty platniczej.png]]

**Edytowanie danych personalnych i kontaktowych**
![[Edytowanie danych personalnych i kontaktowych.png]]

**Generowanie faktury**
![[Generowanie faktury.png]]

**Resetowanie hasła**
![[Resetowanie hasła.png]]

**CMS**
![[CMS.png]]

**Zarządzanie zamówieniami**
![[Zarządzanie zamówieniami.png]]

**Dodawanie produktu do koszyka**
![[Dodawanie produktu do koszyka.png]]
## Projektowanie interfejsu użytkownika

Po jawnym zadeklarowaniu wymagań funkcjonalnych i potrzeb rynkowych, mające swoje odzwierciedlenie **w języku UML**, można przejść do projektowania graficznego interfejsu użytkownika.

Zdecydowano się opisać dokładnie listę **wszystkich ekranów** wraz z funkcjami spełniające **standardy doświadczeń użytkownika**, które znajdują odzwierciedlenie dizajnu w rzeczywistym środowisku:

![[Wymagania.png]]