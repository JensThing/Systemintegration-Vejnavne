# Vejnavne - Opgave til uge 4 på systemintegration
Lavet i .NET 8.

Løsningen har to endpoints
![alt text](image-1.png)

Datafilen er ikke inkluderet i på projektet. 

Datafilen kan hentes [her](https://cpr.dk/Media/638451600706024069/Vejregister_hele_landet_pr_240301.zip)

Beskrivelse af datafilen kan ses [her](https://cpr.dk/media/12197/udtraeksbeskrivelse-vejregister.pdf)

## Opsætning inden kørsel
Man skal sætte stien til datafilen i appsettings.json `DataFilePath`.

## Kørsel af løsningen via http-file
Åbn `Vejnavne.API.http` filen i Vejnavne.API projektet i Visual Studio.

Klik på *Send request* og se svaret.
![alt text](image-3.png)

## Kørsel af løsningen via swagger
Løsningen kan testes via swagger.
![alt text](image.png)
![alt text](image-2.png)