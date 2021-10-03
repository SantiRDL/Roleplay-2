using System;
using System.Collections;

namespace RoleplayGame
{
    public class Encounters
    {
        ArrayList Heroes;
        ArrayList BadGuys;

        /// <summary>
        /// Método para agregar héroes a la lista de héroes.
        /// </summary>
        /// <param name="heroe"></param>
        public void AgregarHeroe(Character heroe)
        {
            this.Heroes.Add(heroe);
        }

        /// <summary>
        /// Método para agregar enemigos a la lista de enemigos.
        /// </summary>
        /// <param name="enemigo"></param>
        public void AgregarEnemigo(Character enemigo)
        {
            this.BadGuys.Add(enemigo);
        }

        /// <summary>
        /// Se fija si en una lista de personajes, hay alguno vivo.
        /// </summary>
        /// <param name="personajes"></param>
        /// <returns></returns>
        public bool HayPersonajesVivos(ArrayList personajes)
        {
            int i = 0;
            int largo = personajes.Count();
            bool vivos = false;
            while (i < largo && !vivos)
            {
                if (personajes[i].Health > 0)
                {
                    vivos = True;
                }
                i = i + 1;
            }
            return vivos;
        }

        /// <summary>
        /// Método que devuelve la cantidad de personajes vivos en un array.
        /// </summary>
        /// <param name="personajes"></param>
        /// <returns></returns>
        public int CantidadPersonajesVivos(ArrayList personajes)
        {
            int i = 0;
            int vivos = 0;
            int largo = personajes.Count();
            while (i < largo)
            {
                if (personajes[i].Health > 0)
                {
                    vivos = vivos + 1;
                }
                i = i + 1;
            }
            return vivos;
        }

        /// <summary>
        /// Método para simular encuentro entre héroes y enemigos.
        /// </summary>
        public void DoEncounter()
        {   
            int i = 0;
            j = 0;
            int largoEnemigos = this.BadGuys.Count();
            int largoHeroes = this.Heroes.Count();
            bool buscar = False;
            bool HeroeVivo = True;
            while (HayPersonajesVivos(this.Heroes) && HayPersonajesVivos(this.BadGuys))
            {
                i = 0; // Resteo variables cada vez que se ejecute el while.
                j = 0;
                largoEnemigos = this.BadGuys.Count();
                largoHeroes = this.Heroes.Count();
                buscar = False;
                // Atacan enemigos primero.
                if (CantidadPersonajesVivos(this.Heroes) == 1)  // Primer caso, varios enemigos y un héroe.
                {
                    while (i < largoEnemigos && HeroeVivo)
                    {
                        while (j < largoHeroes && !buscar)      // Busco dónde está el héroe vivo en el array. Busca la primera vez que se entra al ciclo solamente.
                        {
                            if (this.Heroes[j].Health > 0)
                            {
                                buscar = True;
                                int posicion = j;
                            }
                            j = j + 1;
                        }
                        this.BadGuys[i].Attack(this.Heroes[posicion]);
                        if (this.Heroes[posicion].Health <= 0)
                        {
                            HeroeVivo = False;
                        }
                        i = i + 1;
                    }
                }
                else if (CantidadPersonajesVivos(this.Heroes) >= CantidadPersonajesVivos(this.BadGuys)) // Segundo caso, misma cantidad de héroes que enemigos.
                    {
                        while (i < largoEnemigos)
                        {
                            this.BadGuys[i].Attack(this.Heroes[i]);
                            i = i + 1;
                        }
                    }
                    else        // Tercer caso, hay más enemigos que héroes.
                    {
                        this.BadGuys[j].Attack(this.Heroes[i]);     // El primer enemigo ataca al primer héroe.
                        j = j + 1;                                  // Dentro del ciclo, el siguiente enemigo también ataca al primer héroe.
                        while (i < largoHeroes && j < largoEnemigos)
                        {
                            this.BadGuys[j].Attack(this.Heroes[i]);
                            i = i + 1;
                            j = j + 1; 
                        }
                        if (i == largoHeroes)   // Agrego caso en que la diferencia entre héroes y enemigos sea mayor a uno, varios van a atacar al último héroe.
                        {
                            while (j < largoEnemigos)
                            {
                                this.BadGuys[j].Attack(this.Heroes[i - 1]);
                                j = j + 1;
                            }
                        }
                    }
                // Atacan los héroes, se vuelven a resetear las variables.
                i = 0;
                j = 0;
                while (i < largoHeroes)
                {
                    while (j < largoEnemigos)
                    {
                        this.Heroes[i].Attack(this.BadGuys[j]);
                        if (this.BadGuys[j].Health <= 0)
                        {
                            this.Heroes[i].VP = this.Heroes[i].VP + this.BadGuys[j].VP;
                        }
                        j = j + 1;
                    }
                    i = i + 1;
                }
            }
            // Sale del primer while, es decir, ya no quedan héroes o enemigos. Los héroes vivos con 
            // 5 o más VP, se curan.
            i = 0;
            while (i < largoHeroes)
            {
                if (this.Heroes[i].Health > 0)
                {
                    if (this.Heroes[i].VP >= 5)
                    {
                        this.Heroes[i].Cure();
                    }
                }
                i = i + 1;
            }
        }
    }
}