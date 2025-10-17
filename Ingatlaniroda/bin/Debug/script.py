import csv

# Bemeneti és kimeneti fájlnevek
input_file = 'ingatlanok.csv'
output_file = 'ingatlanok_modositott.csv'

with open(input_file, 'r', encoding='utf-8') as infile, open(output_file, 'w', encoding='utf-8', newline='') as outfile:
    reader = csv.reader(infile, delimiter=';')
    writer = csv.writer(outfile, delimiter=';')
    
    for row in reader:
        # Csak a 8 elemes sorokat dolgozza fel
        if len(row) == 8:
            try:
                # Konvertálás számokra az összehasonlításhoz
                val3 = float(row[2].replace(',', '.'))
                val4 = float(row[3].replace(',', '.'))
                val6 = float(row[5].replace(',', '.'))
                val7 = float(row[6].replace(',', '.'))
                
                # Feltétel ellenőrzés és csere, ha kell
                if val3 > val6 or val4 > val7:
                    row[5], row[6] = row[6], row[5]
            
            except ValueError:
                # Ha nem szám, akkor nem nyúlunk hozzá
                pass
        
        # Mindig írjuk ki a sort (akár módosított, akár nem)
        writer.writerow(row)

print(f"Kész! Az eredmény a(z) '{output_file}' fájlban van.")
