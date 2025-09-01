#EnergyTracker - Backend API

#Description
EnergyTracker est une API d�velopp�e en .NET 9^permettant de g�rer les usagers,contracts et consommations d'�n�rgie.
Elle inclut des fonctionnalit�s avanc�es comme l'exportation de donn�es et la g�n�ration des consommations.

#Pr�requis 
Avant d'ex�cuter le projet assurez-vous de disposer de l'environnement suivant :
.NET 9 SDK : n�cessaire pour compiler et ex�cuter l'API.
SQL Server : Utilis� pour la persistance des donn�es.
Entity Framework Core Tools : pour g�rer les migrations et la base de donn�es.
Visual Studio 2022 (ou Visual Studio Code) : recommand� pour le d�veloppement, le d�bogage et l�ex�cution.

#Installation et lancement 

1. Cloner le projet :
git clone https://github.com/reqqasskaouthar/EnergyTracker.git
cd EnergyTracker

2. Configuration de la base de donn�es
Cr�er une base de don�es SQL Server.
v�rifier ou modifier la chaine de connexion dans appsetting.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EnergyTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

3. Appliquer les migrations :
Ex�cutez la commande suivante pour cr�er la base de donn�es et appliquer les migrations : Update-database

4. Lancer l'API :
L�API sera disponible � l�adresse : 
https://localhost:7090

#Fonctionnalit�s principales
- Gestion des usagers,contrats et consommations.  
- Exportation des donn�es sous format Excel (.xlsx).  
- T�l�chargement de rapports PDF des consommations d�un utilisateur.  
- Documentation Swagger int�gr�e pour tester facilement l�API.  
- Tests unitaires pour garantir la fiabilit� des fonctionnalit�s.  

#Documentation Swagger
Une fois le projet d�marr�, la documentation Swagger est accessible ici :  https://localhost:7090/swagger

#Tests unitaires
Pour ex�cuter les tests unitaires :
- dotnet test
- Si les tests r�ussissent, vous verrez un message similaire � :
Passed!  - Failed: 0, Passed: 7, Skipped: 0, Total: 7

#Auteur
- Kaouthar Reqqass � D�veloppeuse .NET 
