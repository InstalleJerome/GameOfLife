# Principes de conception respectés

## Open/Closed Principle

Dans ce projet, on peut facilement ajouter des fonctionnalités à nos classes sans devoir modifier les classes mères. 

**Exemple** :  
La fonctionnalité d'attaque des TRex. Nous avons pu ajouter les propriétés `lastAttack` et `CanAttack` sans devoir modifier la classe `Animal`.

## Single Responsibility Principle

Lorsque nous souhaitons ajouter une nouvelle fonctionnalité à nos classes, nous créons une nouvelle méthode plutôt que de modifier la fonction `Tick()`. 

**Exemple** :  
Pour ajouter la reproduction, nous avons introduit une méthode `Reproduce` qui se concentre uniquement sur cette responsabilité.