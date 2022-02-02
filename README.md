### TetrisApp
*Réalisé par Olivia MOREAu en C#*
:warning: CE PROJET EST EN COURS DE RÉALISATION :warning:

## Lancement du projet

Pour lancer le projet, il suffit d'aller dans le dossier du projet `TetrisApp` et de lancer la commande suivante : `dotnet watch run`.

## Architecture des fichiers

On retrouve les fichiers avec les classes utiliées dans le dossier Models. On y retrouve les classes `Grid`et `Piece`. On retrouve ensuite le fichier `Options.cs`dans le dossier Data pour pouvoir stocker les options enregistrées.
Les fichiers Razor se trouvent dans le dosser Pages. Il y a `Game`, `Option` et `Credits`. `Game` est le principal utilisé avec toutes les implémentations des classes précédentes et l'affichage de la grille et de ses actions. 

## Avancée du projet :
Pour l'instant nous pouvons :
* Naviguer entre les pages
* Démarrer le jeu
* Ajouter une nouvelle pièce
* Bouger la pièce de gauche à droite, la tourner, la descendre et la placer grâce aux boutons
* Supprimer les lignes pleines
* Augmenter le score

Les problèmes à résoudre :
* Les pièces ne se posent pas au bon endroit (parfois elles se confondent lorsqu'une pièce est déjà mise en place)
* La suppression des lignes ne se fait pas automatiquement
* Il y a des erreurs d'index out of range lors de certaines poses des pièces et lorsque l'on va trop à gauche ou à droite


Les détails à rajouter :
* Pouvoir modifier les options dans la pages /options et qu'elles s'appliquent
* Les pièces doivent pouvoir apparaître automatiquement grâce au timer à mettre en place
* Ajouter les vérifications lorsque la partie est censée être finie
* Ajouter toutes les exceptions possibles
* Prendre en compte les actions via le clavier et non plus grâce aux boutons
* Un CSS propre
