# Simulation d'un écosystème

Dans ce projet, il fallait simuler un écosystème.

## Description de l'écosystème

L'écosystème est composé de :
- **Plantes**  
- **Déchets organiques**  
- **Animaux (carnivores et herbivores)**  

### Règles de fonctionnement
1. **Points de vie et énergie** :  
   - Les animaux et les plantes ont des points de vie (PV) et de l'énergie.  
   - Ils meurent lorsqu'ils n'ont plus de PV.  
   - Les animaux morts deviennent de la viande, qui finit par se transformer en déchet organique.  
   - Les plantes mortes deviennent directement des déchets organiques.  

2. **Chaîne alimentaire** :  
   - Les **carnivores** attaquent les herbivores et se nourrissent de viande.  
   - Les **herbivores** mangent les plantes.  
   - Les **plantes** absorbent les déchets organiques.  
   - Lorsque les objets vivants se nourrissent, ils regagnent de l'énergie.  

## Technologies utilisées

Ce projet a été réalisé avec **AvaloniaUI** en **C#**.