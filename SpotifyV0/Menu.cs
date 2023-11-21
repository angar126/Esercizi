using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class Menu
    {
        string CORNICE = "--------------------------------";
        string VOCE_USCITA = $"E\tEsci";
        string RICHIESTA_INSERIMENTO = "Digita l'opzione desiderata > ";

        private String _titolo;
        private String[] _voci;

        public Menu(string titolo, string[] voci)
        {
            _titolo = titolo;
            _voci = voci;
        }
        public int Choose()
        {
            stampaMenu();
            int result;
            int.TryParse(Console.ReadLine(), out result);
            return result;
        }

        public void stampaMenu()
        {
            Console.WriteLine(CORNICE);
            Console.WriteLine(_titolo);
            Console.WriteLine(CORNICE);
            for (int i = 0; i < _voci.Length; i++)
            {
                Console.WriteLine((i + 1) + "\t" + _voci[i]);
            }
        }

    }
    /*
     * public void viewMenuConfiguratore() {
		Menu menu = new Menu();

		boolean termina = false;

		do {
			switch (menu.Choose()) {
			case 1:
				creaGerarchia();
				break;
			case 2:
				popolaGerarchia();
				break;
			case 3:
				stampaGerarchia();
				break;
			case 4:
				printAll();
				break;
			case 5:
				creaParametriScambio();
				break;
			case 6:
				stampaOfferteAperteCategoria();
				break;
			case 7:
				stampaOfferteInScambioCategoria();
				break;
			case 8:
				stampaOfferteChiuseCategoria();
				break;
			case 9:
				viewMenuImportazioni();

				break;
			case 0:
				termina = exit();
				break;
			}
		} while (!termina);
	}

	private boolean exit() {
		boolean termina;
		termina = true;
		viewUtente.stampaMsgUscita();
		return termina;
	}
     */

}
