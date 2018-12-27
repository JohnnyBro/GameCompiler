using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace GameCompiler.Analizadores
{
    class Gramatica2: Grammar
    {
        public Gramatica2() : base(caseSensitive: false)
        {

            #region ER
            IdentifierTerminal tokId = new IdentifierTerminal("tokId", "_", "");
            var tokNumero = TerminalFactory.CreateCSharpNumber("tokNumero");
            StringLiteral tokCadena = new StringLiteral("tokenCadena", "\"");
            StringLiteral tokChar = new StringLiteral("tokenCaracter", "\'");
            CommentTerminal comentLinea = new CommentTerminal("SingleLineComment", "//", "\r", "\n", "\u2085", "\u2028", "\u2029");
            CommentTerminal comentMulti = new CommentTerminal("DelimitedComment", "/*", "*/");
            NonGrammarTerminals.Add(comentLinea);
            NonGrammarTerminals.Add(comentMulti);
            #endregion

            #region RESERVADAS
            MarkReservedWords("background");
            MarkReservedWords("ancho");
            MarkReservedWords("alto");
            MarkReservedWords("meta");
            MarkReservedWords("x-escenarios");
            MarkReservedWords("x-personajes");
            MarkReservedWords("x-paredes");
            MarkReservedWords("x-extras");
            MarkReservedWords("x-heroes");
            MarkReservedWords("x-villanos");
            MarkReservedWords("x-armas");
            MarkReservedWords("x-bonus");
            #endregion

            #region TERMINALES
            var tokBackground = ToTerm("background");
            var tokAncho = ToTerm("ancho");
            var tokAlto = ToTerm("alto");
            var tokMeta = ToTerm("meta");
            var tokEscenarios = ToTerm("x-escenarios");
            var tokPersonajes = ToTerm("x-personajes");
            var tokParedes = ToTerm("x-paredes");
            var tokExtras = ToTerm("x-extras");
            var tokHeroes = ToTerm("x-heroes");
            var tokVillanos = ToTerm("x-villanos");
            var tokArmas = ToTerm("x-armas");
            var tokBonus = ToTerm("x-bonus");
            var tokMenor = ToTerm("<");
            var tokMayor = ToTerm(">");
            var tokSlash = ToTerm("/");
            var tokComa = ToTerm(",");
            var tokPcoma = ToTerm(";");
            var tokMas = ToTerm("+");
            var tokMenos = ToTerm("-");
            var tokPor = ToTerm("*");
            var tokDiv = ToTerm("/");
            var tokApar = ToTerm("(");
            var tokCpar = ToTerm(")");
            var tokIgual = ToTerm("=");
            var tokPunto = ToTerm(".");
            var tokAescenario = ToTerm("<x-escenarios");
            var tokCescenario = ToTerm("</x-escenarios>");
            var tokApersonajes = ToTerm("<x-personajes>");
            var tokCpersonajes = ToTerm("</x-personajes>");
            var tokAheroes = ToTerm("<x-heroes>");
            var tokCheroes = ToTerm("</x-heroes>");
            var tokAvillanos = ToTerm("<x-villanos>");
            var tokCvillanos = ToTerm("</x-villanos>");
            var tokAparedes = ToTerm("<x-paredes>");
            var tokCparedes = ToTerm("</x-paredes>");
            var tokAextras = ToTerm("<x-extras>");
            var tokCextras = ToTerm("</x-extras>");
            var tokAarmas = ToTerm("<x-armas>");
            var tokCarmas = ToTerm("</x-armas>");
            var tokAbonus = ToTerm("<x-bonus>");
            var tokCbonus = ToTerm("</x-bonus>");
            var tokAmeta = ToTerm("<meta>");
            var tokCmeta = ToTerm("</meta>");


            #endregion

            #region NO TERMINALES
            var INICIO = new NonTerminal("INICIO");
            var CUERPOS = new NonTerminal("CUERPOS");
            var CUERPO = new NonTerminal("CUERPO");
            var PERSONAJES=new NonTerminal("PERSONAJES");
            var CPERSONAJES=new NonTerminal("CPERSONAJES");
            var CPERSONAJE=new NonTerminal("CPERSONAJE");
            var PAREDES=new NonTerminal("PAREDES");
            var CPAREDES = new NonTerminal("CPAREDES");
            var CPARED = new NonTerminal("CPARED");
            var EXTRAS=new NonTerminal("EXTRAS");
            var CEXTRAS = new NonTerminal("CEXTRAS");
            var CEXTRA = new NonTerminal("CEXTRA");
            var META=new NonTerminal("META");
            var CMETAS = new NonTerminal("CMETAS");
            var CMETA = new NonTerminal("CMETA");
            var HEROES = new NonTerminal("HEROES");
            var CHEROES=new NonTerminal("CHEROES");
            var CHEROE=new NonTerminal("CHEROE");
            var VILLANOS=new NonTerminal("VILLANOS");
            var CVILLANOS=new NonTerminal("CVILLANOS");
            var CVILLANO=new NonTerminal("CVILLANO");
            var POSICIONES = new NonTerminal("POSICIONES");
            var POSICION = new NonTerminal("POSICION");
            var ARMAS = new NonTerminal("ARMAS");
            var CARMAS = new NonTerminal("CARMAS");
            var CARMA = new NonTerminal("CARMA");
            var BONUS = new NonTerminal("BONUS");
            var CBONUS = new NonTerminal("CBONUS");
            var CBONU = new NonTerminal("CBONU");


            var EXP = new NonTerminal("EXP");

            #endregion
            
            #region Gramatica
            INICIO.Rule = tokAescenario + tokBackground + tokIgual + tokId + tokPcoma + tokAncho + tokIgual + EXP + tokPcoma + tokAlto + tokIgual + EXP + tokMayor + CUERPOS + tokCescenario
                              ;

            CUERPOS.Rule = MakePlusRule(CUERPOS, CUERPO)
                              ;

            CUERPO.Rule= PERSONAJES
                              | PAREDES
                              | EXTRAS
                              | META
                              ;
            CUERPO.ErrorRule = SyntaxError + ">";

            PERSONAJES.Rule = tokApersonajes + CPERSONAJES + tokCpersonajes
                              ;

            CPERSONAJES.Rule= MakePlusRule(CPERSONAJES,CPERSONAJE)
                              ;

            CPERSONAJE.Rule=HEROES
                              | VILLANOS
                              ;

            HEROES.Rule = tokAheroes + CHEROES + tokCheroes
                              ;

            CHEROES.Rule=MakePlusRule(CHEROES,CHEROE)
                              ;

            CHEROE.Rule=tokId+tokApar+EXP+tokComa+EXP+tokCpar+tokPcoma
                              ;
            CHEROE.ErrorRule = SyntaxError + ";";

            VILLANOS.Rule = tokAvillanos + CVILLANOS + tokCvillanos
                              ;

            CVILLANOS.Rule= MakePlusRule(CVILLANOS, CVILLANO)
                              ;

            CVILLANO.Rule=tokId+tokApar+EXP+tokComa+EXP+tokCpar+tokPcoma
                              ;
            CVILLANO.ErrorRule = SyntaxError + ";";

            PAREDES.Rule = tokAparedes + CPAREDES + tokCparedes
                              ;

            CPAREDES.Rule = MakePlusRule(CPAREDES, CPARED)
                              ;

            CPARED.Rule = tokId + tokApar + POSICIONES + tokCpar + tokPcoma
                              ;
            CPARED.ErrorRule = SyntaxError + ";";

            POSICIONES.Rule = POSICION + tokComa + POSICION
                              ;

            POSICION.Rule = EXP
                              | EXP + tokPunto + tokPunto + EXP
                              ;

            EXTRAS.Rule = tokAextras + CEXTRAS + tokCextras
                              ;

            CEXTRAS.Rule = MakePlusRule(CEXTRAS, CEXTRA)
                              ;

            CEXTRA.Rule = ARMAS
                              | BONUS
                              ;

            ARMAS.Rule = tokAarmas + CARMAS + tokCarmas
                              ;

            CARMAS.Rule = MakePlusRule(CARMAS, CARMA)
                              ;

            CARMA.Rule = tokId + tokApar + EXP + tokComa + EXP + tokCpar + tokPcoma
                              ;
            CARMA.ErrorRule = SyntaxError + ";";

            BONUS.Rule = tokAbonus + CBONUS + tokCbonus
                              ;

            CBONUS.Rule = MakePlusRule(CBONUS, CBONU)
                              ;

            CBONU.Rule = tokId + tokApar + EXP + tokComa + EXP + tokCpar + tokPcoma
                              ;
            CBONU.ErrorRule = SyntaxError + ";";

            META.Rule = tokAmeta + CMETAS + tokCmeta
                              ;

            CMETAS.Rule = MakePlusRule(CMETAS, CMETA)
                              ;

            CMETA.Rule = tokId + tokApar + EXP + tokComa + EXP + tokCpar + tokPcoma
                              ;
            CMETA.ErrorRule = SyntaxError + ";";

            EXP.Rule = EXP + tokMas + EXP
                            | EXP + tokMenos + EXP
                            | EXP + tokPor + EXP
                            | EXP + tokDiv + EXP
                            | tokNumero
                            | tokApar + EXP + tokCpar
                            | tokMenos + EXP
                            ;


            RegisterOperators(1, Associativity.Left, tokMas, tokMenos);
            RegisterOperators(2, Associativity.Left, tokPor, tokDiv);
            RegisterOperators(3, "-()");
            RegisterOperators(4, tokApar + tokCpar);

            this.MarkPunctuation(";", "{", "}", "(", ")",">", tokAescenario.Text, tokApersonajes.Text, tokAheroes.Text, tokAvillanos.Text, tokAparedes.Text, tokAextras.Text, tokAarmas.Text, tokAbonus.Text, tokAmeta.Text,
                tokCescenario.Text, tokCpersonajes.Text, tokCheroes.Text, tokCvillanos.Text, tokCparedes.Text, tokCextras.Text, tokCarmas.Text, tokCbonus.Text, tokCmeta.Text);
            this.MarkTransient(CUERPO, CPERSONAJE, PERSONAJES, VILLANOS, HEROES, PAREDES, EXTRAS, META, CEXTRA, ARMAS, BONUS);
            this.Root = INICIO;
            #endregion


        }
    }
}
