using SdaTithe.Data;
namespace SdaTithe.Services;

public static class Localizer
{
    public static readonly (string Code, string Name)[] Languages =
    {
        ("en", "English"), ("rw", "Kinyarwanda"), ("sw", "Kiswahili"), ("fr", "Français")
    };

    public static string Current { get; private set; } = "en";

    // English text -> { Kinyarwanda, Kiswahili, French }
    private static readonly Dictionary<string, string[]> Map = Build();

    private static Dictionary<string, string[]> Build()
    {
        var d = new Dictionary<string, string[]>();
        void A(string en, string rw, string sw, string fr) => d[en] = new[] { rw, sw, fr };

        // Login and registration
        A("Login", "Injira", "Ingia", "Connexion");
        A("SDA Tithe Management - Login", "Gucunga Icyacumi cya SDA - Injira", "Usimamizi wa Zaka SDA - Ingia", "Gestion des dîmes SDA - Connexion");
        A("Role", "Uruhare", "Wadhifa", "Rôle");
        A("Phone or username", "Telefone cyangwa izina ry'umukoresha", "Simu au jina la mtumiaji", "Téléphone ou nom d'utilisateur");
        A("Password", "Ijambo ry'ibanga", "Nenosiri", "Mot de passe");
        A("Confirm password", "Emeza ijambo ry'ibanga", "Thibitisha nenosiri", "Confirmer le mot de passe");
        A("Create a new account", "Fungura konti nshya", "Fungua akaunti mpya", "Créer un compte");
        A("Register", "Iyandikishe", "Jisajili", "S'inscrire");
        A("Full name", "Amazina yuzuye", "Jina kamili", "Nom complet");
        A("Phone number", "Nimero ya telefone", "Namba ya simu", "Numéro de téléphone");
        A("Phone", "Telefone", "Simu", "Téléphone");
        A("Church", "Itorero", "Kanisa", "Église");
        A("Cancel", "Bireke", "Ghairi", "Annuler");
        A("Save", "Bika", "Hifadhi", "Enregistrer");
        A("Close", "Funga", "Funga", "Fermer");
        A("Log out", "Sohoka", "Toka", "Se déconnecter");
        A("Welcome", "Murakaza neza", "Karibu", "Bienvenue");

        // Dashboards
        A("Member Dashboard", "Urupapuro rw'umunyamuryango", "Dashibodi ya Mwanachama", "Tableau de bord du membre");
        A("Manager Dashboard", "Urupapuro rw'umuyobozi", "Dashibodi ya Kiongozi", "Tableau de bord du responsable");
        A("Amount (RWF)", "Amafaranga (RWF)", "Kiasi (RWF)", "Montant (RWF)");
        A("Amount", "Amafaranga", "Kiasi", "Montant");
        A("Method", "Uburyo", "Njia", "Méthode");
        A("Pay tithe", "Ishyura icyacumi", "Lipa zaka", "Payer la dîme");
        A("View receipt", "Reba inyemezabwishyu", "Tazama risiti", "Voir le reçu");
        A("Receipt", "Inyemezabwishyu", "Risiti", "Reçu");
        A("Receipt no", "Nomero y'inyemezabwishyu", "Namba ya risiti", "N° de reçu");
        A("Print / Save as PDF", "Gucapa / Bika nka PDF", "Chapisha / Hifadhi kama PDF", "Imprimer / Enregistrer en PDF");
        A("SDA Tithe Receipt", "Inyemezabwishyu y'icyacumi cya SDA", "Risiti ya Zaka ya SDA", "Reçu de dîme SDA");
        A("SDA Tithe Report", "Raporo y'icyacumi cya SDA", "Ripoti ya Zaka ya SDA", "Rapport des dîmes SDA");
        A("Member", "Umunyamuryango", "Mwanachama", "Membre");
        A("Date", "Itariki", "Tarehe", "Date");
        A("Received by", "Yakiriwe na", "Imepokelewa na", "Reçu par");
        A("Total this year", "Igiteranyo cy'uyu mwaka", "Jumla mwaka huu", "Total cette année");
        A("Total overall", "Igiteranyo cyose", "Jumla kuu", "Total général");
        A("Number of payments", "Umubare w'ubwishyu", "Idadi ya malipo", "Nombre de paiements");
        A("Search", "Shakisha", "Tafuta", "Rechercher");
        A("New member: name", "Umunyamuryango mushya: izina", "Mwanachama mpya: jina", "Nouveau membre : nom");
        A("Add member", "Ongeraho umunyamuryango", "Ongeza mwanachama", "Ajouter un membre");
        A("Delete selected", "Siba uwatoranyijwe", "Futa aliyechaguliwa", "Supprimer la sélection");
        A("Record cash payment", "Andika ubwishyu bw'amafaranga mu ntoki", "Rekodi malipo ya fedha taslimu", "Enregistrer un paiement en espèces");
        A("Pay my own tithe", "Ishyura icyacumi cyanjye", "Lipa zaka yangu", "Payer ma propre dîme");
        A("Pay your own tithe", "Ishyura icyacumi cyawe", "Lipa zaka yako", "Payez votre propre dîme");
        A("Cash payment for", "Ubwishyu mu ntoki bwa", "Malipo ya fedha taslimu kwa", "Paiement en espèces pour");
        A("Payment", "Ubwishyu", "Malipo", "Paiement");
        A("Account", "Konti", "Akaunti", "Compte");
        A("Yes", "Yego", "Ndiyo", "Oui");
        A("Cash only", "Amafaranga mu ntoki gusa", "Fedha taslimu tu", "Espèces seulement");
        A("Name", "Izina", "Jina", "Nom");
        A("All churches", "Amatorero yose", "Makanisa yote", "Toutes les églises");

        // Reports and analytics
        A("Reports", "Raporo", "Ripoti", "Rapports");
        A("Analytics", "Isesengura", "Uchambuzi", "Analyses");
        A("Period", "Igihe", "Kipindi", "Période");
        A("Date in period", "Itariki iri mu gihe", "Tarehe ndani ya kipindi", "Date dans la période");
        A("Show", "Erekana", "Onyesha", "Afficher");
        A("Week", "Icyumweru", "Wiki", "Semaine");
        A("Month", "Ukwezi", "Mwezi", "Mois");
        A("Year", "Umwaka", "Mwaka", "Année");
        A("Totals by payment method", "Igiteranyo ku buryo bw'ubwishyu", "Jumla kwa njia ya malipo", "Totaux par méthode de paiement");
        A("Totals by member", "Igiteranyo ku munyamuryango", "Jumla kwa mwanachama", "Totaux par membre");
        A("All payments", "Ubwishyu bwose", "Malipo yote", "Tous les paiements");
        A("Collected per day (RWF)", "Ibyakusanyijwe ku munsi (RWF)", "Kilichokusanywa kwa siku (RWF)", "Collecté par jour (RWF)");
        A("Collected per month (RWF)", "Ibyakusanyijwe ku kwezi (RWF)", "Kilichokusanywa kwa mwezi (RWF)", "Collecté par mois (RWF)");
        A("Last 12 months (RWF)", "Amezi 12 ashize (RWF)", "Miezi 12 iliyopita (RWF)", "12 derniers mois (RWF)");
        A("Payment method shares (this year)", "Ijanisha ry'uburyo bw'ubwishyu (uyu mwaka)", "Mgawanyo wa njia za malipo (mwaka huu)", "Répartition des méthodes de paiement (cette année)");
        A("No data for this selection.", "Nta makuru ahari kuri iri hitamo.", "Hakuna data kwa chaguo hili.", "Aucune donnée pour cette sélection.");
        A("Total collected", "Igiteranyo cyakusanyijwe", "Jumla iliyokusanywa", "Total collecté");
        A("Total", "Igiteranyo", "Jumla", "Total");
        A("Payments", "Ubwishyu", "Malipo", "Paiements");
        A("Average payment", "Impuzandengo y'ubwishyu", "Wastani wa malipo", "Paiement moyen");
        A("Average", "Impuzandengo", "Wastani", "Moyenne");
        A("Rank", "Umwanya", "Nafasi", "Rang");
        A("Total collected this year", "Igiteranyo cyakusanyijwe uyu mwaka", "Jumla iliyokusanywa mwaka huu", "Total collecté cette année");
        A("Total this month", "Igiteranyo cy'uku kwezi", "Jumla mwezi huu", "Total ce mois-ci");
        A("last month", "ukwezi gushize", "mwezi uliopita", "mois dernier");
        A("vs last month", "ugereranyije n'ukwezi gushize", "ikilinganishwa na mwezi uliopita", "par rapport au mois dernier");
        A("no data last month", "nta makuru y'ukwezi gushize", "hakuna data ya mwezi uliopita", "pas de données le mois dernier");
        A("Number of members", "Umubare w'abanyamuryango", "Idadi ya wanachama", "Nombre de membres");
        A("Active givers this month", "Abatanze muri uku kwezi", "Waliotoa mwezi huu", "Donateurs actifs ce mois-ci");
        A("participation", "uruhare", "ushiriki", "participation");
        A("Average given per member (this year)", "Impuzandengo ku munyamuryango (uyu mwaka)", "Wastani kwa mwanachama (mwaka huu)", "Moyenne par membre (cette année)");
        A("Members with no payment in 60 days", "Abatarishyuye mu minsi 60", "Wanachama wasiolipa ndani ya siku 60", "Membres sans paiement depuis 60 jours");
        A("Church ranking (this year)", "Urutonde rw'amatorero (uyu mwaka)", "Orodha ya makanisa (mwaka huu)", "Classement des églises (cette année)");

        // Messages
        A("Wrong phone/username or password.", "Telefone/izina ry'umukoresha cyangwa ijambo ry'ibanga si byo.", "Simu/jina la mtumiaji au nenosiri si sahihi.", "Téléphone/nom d'utilisateur ou mot de passe incorrect.");
        A("This account does not have the chosen role.", "Iyi konti nta ruhare yahisemo ifite.", "Akaunti hii haina wadhifa uliochagua.", "Ce compte n'a pas le rôle choisi.");
        A("Please choose a church.", "Hitamo itorero.", "Tafadhali chagua kanisa.", "Veuillez choisir une église.");
        A("Choose a church first.", "Banza uhitemo itorero.", "Chagua kanisa kwanza.", "Choisissez d'abord une église.");
        A("Account created. You can now log in.", "Konti yafunguwe. Ubu ushobora kwinjira.", "Akaunti imeundwa. Sasa unaweza kuingia.", "Compte créé. Vous pouvez maintenant vous connecter.");
        A("Full name cannot be empty.", "Amazina yuzuye ntagomba gusigara ubusa.", "Jina kamili haliwezi kuwa tupu.", "Le nom complet ne peut pas être vide.");
        A("Phone number must be at least 10 characters.", "Nimero ya telefone igomba kuba nibura imibare 10.", "Namba ya simu lazima iwe na angalau tarakimu 10.", "Le numéro de téléphone doit contenir au moins 10 caractères.");
        A("This phone number is already registered.", "Iyi nimero ya telefone yamaze kwandikwa.", "Namba hii ya simu tayari imesajiliwa.", "Ce numéro de téléphone est déjà enregistré.");
        A("Password is required.", "Ijambo ry'ibanga ni ngombwa.", "Nenosiri linahitajika.", "Le mot de passe est obligatoire.");
        A("Passwords do not match.", "Amagambo y'ibanga ntabwo ahura.", "Manenosiri hayalingani.", "Les mots de passe ne correspondent pas.");
        A("Enter a valid amount in numbers.", "Andika amafaranga yemewe mu mibare.", "Weka kiasi sahihi kwa tarakimu.", "Entrez un montant valide en chiffres.");
        A("Minimum tithe amount is 100 RWF.", "Icyacumi gito ni 100 RWF.", "Kiwango cha chini cha zaka ni RWF 100.", "Le montant minimum de la dîme est de 100 RWF.");
        A("Choose a payment method.", "Hitamo uburyo bwo kwishyura.", "Chagua njia ya malipo.", "Choisissez une méthode de paiement.");
        A("Your account has no church.", "Konti yawe nta torero ifite.", "Akaunti yako haina kanisa.", "Votre compte n'a pas d'église.");
        A("Select a payment first.", "Banza uhitemo ubwishyu.", "Chagua malipo kwanza.", "Sélectionnez d'abord un paiement.");
        A("Select a member first.", "Banza uhitemo umunyamuryango.", "Chagua mwanachama kwanza.", "Sélectionnez d'abord un membre.");
        A("Receipt not found.", "Inyemezabwishyu ntiyabonetse.", "Risiti haikupatikana.", "Reçu introuvable.");
        A("Member not found.", "Umunyamuryango ntiyabonetse.", "Mwanachama hajapatikana.", "Membre introuvable.");
        A("You can only manage members of your own church.", "Ushobora gucunga abanyamuryango b'itorero ryawe gusa.", "Unaweza kusimamia wanachama wa kanisa lako tu.", "Vous ne pouvez gérer que les membres de votre église.");
        A("The date cannot be in the future.", "Itariki ntishobora kuba iri imbere.", "Tarehe haiwezi kuwa ya baadaye.", "La date ne peut pas être dans le futur.");
        A("Delete this member and all their payments?", "Gusiba uyu munyamuryango n'ubwishyu bwe bwose?", "Kufuta mwanachama huyu na malipo yake yote?", "Supprimer ce membre et tous ses paiements ?");
        A("Confirm delete", "Emeza gusiba", "Thibitisha kufuta", "Confirmer la suppression");
        return d;
    }

    // ---------- loading and saving the chosen language ----------
    public static void Load()
    {
        using var c = Db.Open();
        using var create = c.CreateCommand();
        create.CommandText = "CREATE TABLE IF NOT EXISTS Settings (Key TEXT PRIMARY KEY, Value TEXT)";
        create.ExecuteNonQuery();

        using var get = c.CreateCommand();
        get.CommandText = "SELECT Value FROM Settings WHERE Key='language'";
        if (get.ExecuteScalar() is string v && Languages.Any(l => l.Code == v)) Current = v;
    }

    public static void Set(string code)
    {
        Current = code;
        using var c = Db.Open();
        using var cmd = c.CreateCommand();
        cmd.CommandText = "INSERT OR REPLACE INTO Settings (Key, Value) VALUES ('language', @v)";
        cmd.Parameters.AddWithValue("@v", code);
        cmd.ExecuteNonQuery();
    }

    // ---------- translating text ----------
    // Translates a whole text, or the part before ": " / ", " (for "Total: 5,000 RWF").
    public static string T(string text)
    {
        if (Current == "en" || string.IsNullOrEmpty(text)) return text;
        int i = Array.FindIndex(Languages, l => l.Code == Current) - 1;   // rw=0, sw=1, fr=2

        if (Map.TryGetValue(text, out var tr)) return tr[i];
        foreach (var sep in new[] { ": ", ", " })
        {
            int p = text.IndexOf(sep, StringComparison.Ordinal);
            if (p > 0 && Map.TryGetValue(text[..p], out var t2))
                return t2[i] + sep + text[(p + sep.Length)..];
        }
        return text;
    }

    // ---------- translating whole forms ----------
    private sealed class Src { public string Source = ""; public string Shown = ""; }
    private static bool _busy;
    private static bool _syncing;

    // Translates every label, button and title on the form, and keeps translating
    // any text the code sets later (error messages, totals, and so on).
    public static void Apply(Control root)
    {
        Translate(root);
        foreach (Control c in root.Controls) Apply(c);
    }

    private static void Translate(Control c)
    {
        if (c is DataGridView g) { HookGrid(g); return; }
        if (c is not (Label or ButtonBase or Form or GroupBox)) return;

        if (c.Tag is not Src s)
        {
            s = new Src { Source = c.Text };
            c.Tag = s;
            c.TextChanged += OnTextChanged;
        }
        Show(c, s);
    }

    private static void OnTextChanged(object? sender, EventArgs e)
    {
        if (_busy || sender is not Control c || c.Tag is not Src s) return;
        if (c.Text == s.Shown) return;     // our own change
        s.Source = c.Text;                 // new English text set by the code
        Show(c, s);
    }

    private static void Show(Control c, Src s)
    {
        var shown = T(s.Source);
        s.Shown = shown;
        if (c.Text == shown) return;
        _busy = true;
        try { c.Text = shown; } finally { _busy = false; }
    }

    private static void HookGrid(DataGridView g)
    {
        if (g.Tag == null)
        {
            g.Tag = "hooked";
            g.DataBindingComplete += (s, e) => TranslateHeaders(g);
        }
        TranslateHeaders(g);
    }

    private static void TranslateHeaders(DataGridView g)
    {
        foreach (DataGridViewColumn col in g.Columns) col.HeaderText = T(col.Name);
    }

    // ---------- the language drop-down ----------
    public static void BindSelector(ComboBox cmb, Action? onChanged = null)
    {
        cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        cmb.Items.Clear();
        foreach (var l in Languages) cmb.Items.Add(l.Name);
        SyncSelector(cmb);
        cmb.SelectedIndexChanged += (s, e) =>
        {
            if (_syncing || cmb.SelectedIndex < 0) return;
            Set(Languages[cmb.SelectedIndex].Code);
            onChanged?.Invoke();
        };
    }

    public static void SyncSelector(ComboBox cmb)
    {
        _syncing = true;
        try { cmb.SelectedIndex = Array.FindIndex(Languages, l => l.Code == Current); }
        finally { _syncing = false; }
    }
}