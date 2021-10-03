using System.Collections.Generic;

namespace RoleplayGame
{
    public class Encounters
    {
        private List<Character> heroes;
        private List<Character> badGuys;

        /// <summary>
        /// Método para agregar personajes a su respectiva lista.
        /// </summary>
        /// <param name="heroe"></param>
        public void AgregarPersonaje(Character character)
        {
            if (character.IsHero)
            {
                this.heroes.Add(character);
            }
            else
            {
                this.badGuys.Add(character);
            }
        }

        /// <summary>
        /// Se fija si en una lista de personajes, hay alguno vivo.
        /// </summary>
        /// <param name="personajes"></param>
        /// <returns></returns>
        public bool HayPersonajesVivos(List<Character> personajes)
        {
            int i = 0;
            int largo = personajes.Count;
            bool vivos = false;
            while (i < largo && !vivos)
            {
                if (personajes[i].Health > 0)
                {
                    vivos = true;
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
        public int CantidadPersonajesVivos(List<Character> personajes)
        {
            int i = 0;
            int vivos = 0;
            int largo = personajes.Count;
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
            int largoEnemigos = this.badGuys.Count;
            int largoHeroes = this.heroes.Count;
            while (HayPersonajesVivos(this.heroes) && HayPersonajesVivos(this.badGuys))
            {
                foreach (Character enemigo in badGuys)
                {
                    i = 0;
                    enemigo.Attack(this.heroes[i]);
                    if (i == largoHeroes - 1)
                    {
                        i = 0;
                    }
                    else
                    {
                        i += 1;
                    }
                }

                if (HayPersonajesVivos(this.heroes))
                {
                    foreach (Character hero in this.heroes)
                    {
                        foreach(Character enemigo in this.badGuys)
                        {
                            hero.Attack(enemigo);
                            if (enemigo.Health <= 0)
                            {
                                hero.VP += enemigo.VP;
                                enemigo.VP = 0;
                            }
                            if (hero.VP >= 5)
                            {
                                hero.Cure();
                            }
                            
                        }
                    }
                }
            }
        }
    }
}