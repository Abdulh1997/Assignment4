# SW4BED - Assignment 4 - GROUP 7

> Til denne test er det en god idé at have DockerDesktop installeret som kan installeres [her](https://www.docker.com/products/docker-desktop/). Det bliver også nødvendigt at have Postman installeret, det kan installeres [her](https://www.postman.com/downloads/).
## Quick Guide

1. I en terminal skal du navigere til mappen hvor projektet er placeret med: `cd <path-to-folder>`
2. I terminalen i den korrekte sti skrives: `docker-compose up -d` herefter køres docker-compose-filen, som henholdsvis henter images for MongoDB og MongoExpress samt bygger image af VS-solution med Dockerfile.
3. Når docker-compose-filen har kørt færdigt kan programmet testes med den givende Postman test [med denne fil](https://github.com/bvda/sw4bed-01/blob/main/assignments/assignment4/SW4BED-01%20Handin%204.postman_collection.json). Denne JSON fil kan importeres i Postman ved at trykke `import` i venstre-menu, og så enten importere filen eller copy-paste raw text.
3.1 Når testen køres kan det være at Postman brokker sig over med noget authentication f.eks. SSL-authentication, dette kan slås fra i Postman til denne test.
4. Det er også muligt at tilgå SwaggerUI på API'en som køres lokalt på computeren, den kan tilgås på: `https://localhost:5000/swagger` når compose-filen kører korrekt med containers, men den reele test skal køres med Postman, da Swagger f.eks. har svært ved at hente all `Cards`.
