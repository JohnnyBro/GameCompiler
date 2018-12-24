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
            #endregion

            #region NO TERMINALES
            var INICIO = new NonTerminal("INICIO");
            var CUERPOS = new NonTerminal("CUEPOS");
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
            INICIO.Rule = tokMenor + tokEscenarios + tokBackground + tokIgual + tokId + tokPcoma + tokAncho + tokIgual + EXP + tokPcoma + tokAlto + tokIgual + EXP  + tokMayor + CUERPOS + tokMenor + tokSlash + tokEscenarios + tokMayor
                              ;

            CUERPOS.Rule = MakePlusRule(CUERPOS, CUERPO)
                              ;

            CUERPO.Rule= PERSONAJES
                              | PAREDES
                              | EXTRAS
                              | META
                              ;

            PERSONAJES.Rule = tokMenor + tokPersonajes + tokMayor + CPERSONAJES + tokMenor + tokSlash + tokPersonajes + tokMayor
                              ;

            CPERSONAJES.Rule= MakePlusRule(CPERSONAJES,CPERSONAJE)
                              ;

            CPERSONAJE.Rule=HEROES
                              | VILLANOS
                              ;

            HEROES.Rule=tokMenor+tokHeroes+tokMayor+CHEROES+tokMenor+tokSlash+tokHeroes+tokMayor
                              ;

            CHEROES.Rule=MakePlusRule(CHEROES,CHEROE)
                              ;

            CHEROE.Rule=tokId+tokApar+EXP+tokComa+EXP+tokCpar+tokPcoma
                              ;

            VILLANOS.Rule=tokMenor+tokVillanos+tokMayor+CVILLANOS+tokMenor+tokSlash+tokVillanos+tokMayor
                              ;

            CVILLANOS.Rule= MakePlusRule(CVILLANOS, CVILLANO)
                              ;

            CVILLANO.Rule=tokId+tokApar+EXP+tokComa+EXP+tokCpar+tokPcoma
                              ;

            PAREDES.Rule = tokMenor + tokParedes + tokMayor + CPAREDES + tokMenor + tokSlash + tokParedes + tokMayor
                              ;

            CPAREDES.Rule = MakePlusRule(CPAREDES, CPARED)
                              ;

            CPARED.Rule = tokId + tokApar + POSICIONES + tokCpar + tokPcoma
                              ;

            POSICIONES.Rule = POSICION + tokComa + POSICION
                              ;

            POSICION.Rule = EXP
                              | EXP + tokPunto + tokPunto + EXP
                              ;

            EXTRAS.Rule = tokMenor + tokExtras + tokMayor + CEXTRAS + tokMenor + tokSlash + tokExtras + tokMayor
                              ;

            CEXTRAS.Rule = MakePlusRule(CEXTRAS, CEXTRA)
                              ;

            CEXTRA.Rule = ARMAS
                              | BONUS
                              ;

            ARMAS.Rule = tokMenor + tokArmas + tokMayor + CARMAS + tokMenor + tokSlash + tokArmas + tokMayor
                              ;

            CARMAS.Rule = MakePlusRule(CARMAS, CARMA)
                              ;

            CARMA.Rule = tokId + tokApar + EXP + tokComa + EXP + tokCpar + tokPcoma
                              ;

            BONUS.Rule = tokMenor + tokBonus + tokMayor + CBONUS + tokMenor + tokSlash + tokBonus + tokMayor
                              ;

            CBONUS.Rule = MakePlusRule(CBONUS, CBONU)
                              ;

            CBONU.Rule = tokId + tokApar + EXP + tokComa + EXP + tokCpar + tokPcoma
                              ;

            META.Rule = tokMenor + tokMeta + tokMayor + CMETAS + tokMenor + tokSlash + tokMeta + tokMayor
                              ;

            CMETAS.Rule = MakePlusRule(CMETAS, CMETA)
                              ;

            CMETA.Rule = tokId + tokApar + EXP + tokComa + EXP + tokCpar + tokPcoma
                              ;

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

            this.Root = INICIO;
            #endregion


        }
    }
}
