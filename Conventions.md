## conventies voor E5_MakkersMarkt

## Inhoudsopgave
1. [Naming Conventions](#naming-conventions)
2. [Indentatie](#indentatie)
3. [Wit Ruimte's](#witte-ruimte)
4. [Commentaar](#commentaar)
5. [Functies](#functies)
6. [Fout Preventie](#Fout-Preventie)
7. [Bestandsnamen en Mappenstructuur](#bestandsnamen-en-mappenstructuur)
   7.1[Mappen](#mappen)
   7.2[Bestanden](#bestanden)
8. [Werken met Git](#git)

---

## Naming Conventions
- **Variabelen en functies**: Gebruik `UperCamelCase` voor functies en `lowerCamelCase` voor variabelen.

## Wit Ruimte's
- niet al te veel witruimtes > hou het beperkt tot max 2 regel ertussen

## Indentatie
- **indentatie**: parent child relation. Als een stuk code een child is van een ander stuk code, zorg er dan voor dat die met tab eronder staat.

## Commentaar
- **comments**: gebruik bij wat complexere dingen en bijv niet bij het standart crud reeks.

## Functies
- Naam van functie geeft aan wat er in de functie gedaan wordt.
- Als we in een functie verbinding met de database willen maken gebruiken we AppDbContext.

## Fout Preventie
- voor fouten eerst kijken en weeten wat er fout is en dan nog niet git pushen zoadat er geen foute code gepublished wordt en dat er geen gitconflicten komen

## Bestandsnamen en Mappenstructuur
- De structuur en naamconventies zijn vastgesteld in de alpha-versie van het project.
- Hieronder vind je een uitleg over de structuur.

### Mappen
- Mappen zijn verdeeld in drie categorieën:
  1. Eerste rangs
  2. Tweede rangs
  3. Derde rangs

#### Eerste Rangs
- Mapnamen zijn in het Engels en beginnen met een hoofdletter.
- Voorbeelden van eerste rangs mappen:
  1. Auth
  2. Data
  3. Pages

- Deze mappen worden genoemd naar  van MakkersMarkt. Namen van eerste rangs mappen kunnen daarvan niet afwijken. Voorbeelden van incorrecte namen:
  1. verkoop (begint niet met een hoofdletter)
  2. Marketing (is geen page binnen MakkersMarkt)
  3. Inkoop (is in het Nederlands, niet in het Engels)

- In de eerste rangs map bevinden **alleen** mappen van de tweede rang en **niks** anders. 

#### Tweede Rangs
- Voor tweede rangs mappen gelden grotendeels dezelfde conventies als bij de eerste rangs, met twee afwijkingen:
  1. Namen zijn gebaseerd op beroep in plaats van afdeling. ( kooper / verkooper )
  2. Andere bestanden mogen daar ook in staan. **Let op**: Dit geldt alleen voor bestanden die bij dat beroep horen. Bestanden die niet bij dat beroep horen, mogen daar niet in worden opgeslagen. Bestanden die bij het beroep "koper" horen, mogen bijvoorbeeld niet worden opgeslagen in de map voor het beroep "koper".

- Mappen die in een tweede rangs map zitten, worden derde rangs mappen genoemd. Derde rangs mappen zijn *optioneel*, maar het gebruik ervan wordt aangeraden voor een nettere mappenstructuur.
  
#### Derde Rangs (*optioneel*)
- In een derde rangs map vind je bestanden die een aparte locatie hebben omdat ze een functionaliteit van het hoofdbestand ondersteunen. Een voorbeeld: de inkoper ziet op het dashboard in de tweede rangs map van inkoop dat van bepaalde producten de voorraad bijna op is. De inkoper kan dan op een product klikken en wordt geleid naar de inkooppagina die in een derde rang map zit om daar de aankoop van het product te voltooien.

### bestanden
- Bestanden zijn niet verdeeld in verschillende categorieën zoals bij mappen, maar volgen bijna dezelfde regels als bij de mappen. Bestandensnamen zijn in het Engels, beginnen met een hoofdletter en zijn aan elkaar geschreven met het woord Page achteraan. Bestanden bevinden alleen in een tweede rangsmap en kan ook bevinden in een derde rangsmap, maar niet in een eerste rangsmap.

- Hierbij gelden een aantal uitzonderingen. De uitzonderingen zijn:
   1. De bestanden in de map Data
   2. Bestanden die Visual Studio standaard aanmaakt bij het aanmaken van een project
 
- Voor bestanden in de derde rangsmappen moeten vernoemd worden naar de functionaliteit die ze ondersteunen. Ook hierbij geldt dat de bestandsnaam in het Engels is en begint met een hoofdletter, eindigt met het woord Page en aan elkaar zit.

## Git
- Als meer mensen in hetzelfde bestand aan het werken zijn moet er met branches gewerkt worden.
- Commits met een korte titel die beschrijft wat er is veranderd of toegevoegd is.
- Commits in het Engels.
