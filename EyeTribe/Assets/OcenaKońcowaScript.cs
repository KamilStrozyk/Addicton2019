using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcenaKońcowaScript : MonoBehaviour
{
    private float creativity;
    private float temperament;
    private float optimism;
    private float simplicity;
    private float socialSkills;
    private float selfControl;
    private GameManager GM;
    public string wynik_koncowy ="";

    void Maxi()
    {
        if (creativity >= temperament && creativity >= optimism && creativity >= simplicity && creativity >= socialSkills && creativity >= selfControl)
            wynik_koncowy = "Melancholik:\nTwój temperament charakteryzuje perfekcjonizm, jesteś skłonny\n do skrajnego przeżywania sukcesów, jak i porażek.\n" +
                "Starasz się jednak tego nie ujawniać.\n Jesteś utalentowany i sumienny - spróbuj to wykorzystać!\n Często okazujesz empatię, jednak " +
                "zdarzają Ci się gorsze dni,\n w których jesteś pesymistą i introwertykiem.\nStaraj się je w miarę możliwości ograniczać,\na będziesz czuł się lepiej.";
        if (creativity <= temperament && temperament >= optimism && temperament >= simplicity && temperament >= socialSkills && temperament >= selfControl)
            wynik_koncowy = "Choleryk\nJesteś energicznym ekstrawertykiem.\nPosiadasz zdolności przywódcze, wykazujesz postawę proaktywną,\na Twoje działania cechuje dynamizm.\nMożesz spróbować " +
                "poprawadzić jakiś projekt - rozwinie\n to Twoje umięjętności, a pozwoli przy tym\n miło spędzić czas. Uważaj jednak, bo czasem stajesz się\n autorytarny i innym ludziom" +
                "może być ciężko współpracować z Tobą.\n Masz przy tym silną wolę, jesteś zdeterminowany i zdecydowany - wykorzystaj to,\n" +
                "nie zniechęcaj się w obliczu porażek. Uważaj, Twój temperament\n wykazuje jednak również skłonności do pracoholizmu - musisz\ndbać o siebie i innych: " +
                "robić regularne przerwy, pamiętać o\n odstresowaniu - praca musi być ważna, ale nie może być całym Twoim życiem.";
        if (optimism >= creativity && optimism >= temperament && optimism >= simplicity && optimism >= socialSkills && optimism >= selfControl)
            wynik_koncowy = "Gorącokrwisty/Sangwinik\nCechuje Cię entuzjazm wraz z otwarciem na ludzi i nowe wyzwania.\n Jesteś optymistą. " +
                "Twórczość to Twoja mocna strona. Spróbuj rozwinąć się\nartystycznie - może zainteresuje Cię muzyka, plastyka lub\ngra aktorska? " +
                "Jesteś też osobą bardzo komunikatywną,\nwykazujesz się postawami proaktywnymi. Uważaj jednak,\nbo ludzie o takim charakterze, zwani wylewnymi ekstrawertykami," +
                "często mają\n problem ze skrywaniem uczuć, a to czasami może obrócić się przeciwko Tobie.";
        if (selfControl >= creativity && selfControl >= temperament && selfControl >= simplicity && selfControl >= socialSkills && optimism <= selfControl)
            wynik_koncowy = "Flegmatyk\nJesteś raczej spokojnym i opanowanym człowiekiem.\n Zawsze starasz się słuchać rozmówcy, jesteś\n dla niego uprzejmy" +
                " i koncentrujesz się na rozmowie.\n Twoją mocną stroną są mediacje - możesz\n rozwijać się w tym kierunku, a w przyszłości\n masz szansę zostać znanym " +
                "prawnikiem lub mediatorem.\n Jesteś też doskonałym obserwatorem - nic nie\n umknie przed Twoim wzrokiem. Ludzi takich\n jak Ty nazwywa się introwertykami.";
        else if (wynik_koncowy == "")
            wynik_koncowy = "Nie mozna było zdefiniować Twojej osobowości";         //TODO: opracowac wiecej rozwiazan zwiazanych z analiza wynikow
    }



    // Start is called before the first frame update
    void Start()
    {
        creativity = GM.Creativity;
        temperament = GM.Temperament;
        optimism = GM.Optymism;
        simplicity = GM.Simplicity;
        socialSkills = GM.SocialSkills;
        selfControl = GM.SelfControl;
      
    }
    private void Update()
    {
        Maxi();
        this.gameObject.GetComponent<TextMesh>().text = wynik_koncowy;
    }
}