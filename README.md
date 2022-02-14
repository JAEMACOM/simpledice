# simpledice

## Kompilieren
- ASPDice.sln mit Visual Studio 2022 öffnen
- Sollte es zu Kompilierfehler kommen:
	1. Mit rechter Maustaste auf "Abhängigkeiten" klicken
	2. Klicken auf "NuGet-Pakette verwalten"
	3. Klicken auf Tab "Nuget-ASPDice" und danach "Durchsuchen"
	4. Suche nach "App.Metrics.AspNetCore"
	5. Klicken auf der Auswahl auf "App.Metrics.AspNetCore" und danach "Installieren"
	6. Suche nach "App.Metrics.AspNetCore.EndPoints" und installiere
	7. Suche nach "App.Metrics.AspNetCore.Tracking" und installiere
	8. Suche nach "App.Metrics.Formatters.Prometheus" und installiere

	Wenn das Programm startet im Development Modus wird es mit "swagger" gestartet.
	Jetzt kann man die Services testen.
	Möchte man ohne "swagger" starten, dann direkt über 
		1. "localhost:7201/Dice", um einen Wurf durchzuführen
		2. "localhost:7201/DiceList", um die gesamte Liste aller bis jetzt geworfenen Werte zu bekommen
		Die 7201 kann eventuell eine andere nummer sein, bitte überprüfen welche Nummer das ist, in der URL, die im Browser erscheint, wenn das Programm gestartet wird

## Prometheus konfigurieren und verbinden:
	1. Prometheus installieren, falls es noch nicht installiert ist
	2. Die konfigurationsdatei "prometheus.yml" mit folgenden Änderungen anpassen:

	  - job_name: 'ASPDice'
    scrape_interval: 5s
    static_configs:
      - targets: ['localhost:7201']
    metrics_path: /metrics-text
    scheme: https

	3. Prometheus mit Aufruf vom "prometheus.exe" starten
	4. Über den Browser mit "localhost:9090" den Client von Prometheus starten
	5. Den Befehl: "application_httprequests_active" eingeben und auf "Execute" klicken
	6. Wenn alles gut läuft sollte in etwa :"application_httprequests_active{app="ASPDice", env="development", instance="localhost:7201", job="ASPDice", server="KOSTASPC"}" erscheinen.
	7. Prometheus ist jetzt verbunden


Viel Spass beim würfeln und möge die 6 bei Dir sein! :)
