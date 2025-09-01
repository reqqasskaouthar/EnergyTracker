#EnergyTracker - Backend API

#Description
EnergyTracker est une API développée en .NET 9^permettant de gérer les usagers,contracts et consommations d'énérgie.
Elle inclut des fonctionnalités avancées comme l'exportation de données et la génération des consommations.

#Prérequis 
Avant d'exécuter le projet assurez-vous de disposer de l'environnement suivant :
.NET 9 SDK : nécessaire pour compiler et exécuter l'API.
SQL Server : Utilisé pour la persistance des données.
Entity Framework Core Tools : pour gérer les migrations et la base de données.
Visual Studio 2022 (ou Visual Studio Code) : recommandé pour le développement, le débogage et l’exécution.

#Installation et lancement 

1. Cloner le projet :
git clone https://github.com/reqqasskaouthar/EnergyTracker.git
cd EnergyTracker

2. Configuration de la base de données
Créer une base de donées SQL Server.
vérifier ou modifier la chaine de connexion dans appsetting.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EnergyTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

3. Appliquer les migrations :
Exécutez la commande suivante pour créer la base de données et appliquer les migrations : Update-database

4. Lancer l'API :
L’API sera disponible à l’adresse : 
https://localhost:7090

#Fonctionnalités principales
- Gestion des usagers,contrats et consommations.  
- Exportation des données sous format Excel (.xlsx).  
- Téléchargement de rapports PDF des consommations d’un utilisateur.  
- Documentation Swagger intégrée pour tester facilement l’API.  
- Tests unitaires pour garantir la fiabilité des fonctionnalités.  

#Documentation Swagger
Une fois le projet démarré, la documentation Swagger est accessible ici :  https://localhost:7090/swagger

#Tests unitaires
Pour exécuter les tests unitaires :
- dotnet test
- Si les tests réussissent, vous verrez un message similaire à :
Passed!  - Failed: 0, Passed: 7, Skipped: 0, Total: 7

#Auteur
- Kaouthar Reqqass – Développeuse .NET 
