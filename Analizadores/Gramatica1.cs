using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;


namespace GameCompiler.Analizadores
{
    class Gramatica1 : Grammar
    {
        public Gramatica1() : base (caseSensitive: false)
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
            MarkReservedWords("configuration");
            MarkReservedWords("background");
            MarkReservedWords("figure");
            MarkReservedWords("design");
            MarkReservedWords("x-nombre");
            MarkReservedWords("x-imagen");
            MarkReservedWords("x-tipo");
            MarkReservedWords("x-vida");
            MarkReservedWords("x-heroe");
            MarkReservedWords("x-enemigo");
            MarkReservedWords("x-destruir");
            MarkReservedWords("x-descripcion");
            MarkReservedWords("x-bomba");
            MarkReservedWords("x-arma");
            MarkReservedWords("x-creditos");
            MarkReservedWords("x-meta");
            MarkReservedWords("x-bloque");
            MarkReservedWords("x-bonus");
            MarkReservedWords("x-arma");
            MarkReservedWords("x-bomba");
            #endregion

            #region TERMINALES
            var tokConfig = ToTerm("configuration");
            var tokBackground = ToTerm("background");
            var tokFigure = ToTerm("figure");
            var tokDesign = ToTerm("design");
            var tokNombre = ToTerm("x-nombre");
            var tokImagen = ToTerm("x-imagen");
            var tokTipo = ToTerm("x-tipo");
            var tokVida = ToTerm("x-vida");
            var tokHero = ToTerm("x-heroe");
            var tokEnemy = ToTerm("x-enemigo");
            var tokDestruir = ToTerm("x-destruir");
            var tokDescripcion = ToTerm("x-descripcion");
            var tokBomba = ToTerm("x-bomba");
            var tokArma = ToTerm("x-arma");
            var tokCreditos = ToTerm("x-creditos");
            var tokMeta = ToTerm("x-meta");
            var tokBloque = ToTerm("x-bloque");
            var tokBonus = ToTerm("x-bonus");
            var tokMenor = ToTerm("<");
            var tokMayor = ToTerm(">");
            var tokSlash = ToTerm("/");
            var tokAllave = ToTerm("{");
            var tokCllave = ToTerm("}");
            var tokComa = ToTerm(",");
            var tokPcoma = ToTerm(";");
            var tokIgual = ToTerm("=");
            var tokMas = ToTerm("+");
            var tokMenos = ToTerm("-");
            var tokPor = ToTerm("*");
            var tokDiv = ToTerm("/");
            var tokApar = ToTerm("(");
            var tokCpar = ToTerm(")");

            
            #endregion

            #region NO TERMINALES
            var START = new NonTerminal("START");
            var BODIES = new NonTerminal("BODIES");
            var BODY = new NonTerminal("BODY");
            //var CONFIG = new NonTerminal("CONFIG");
            var LABELBACKGROUND = new NonTerminal("LABELBACKGROUND");
            var BACKGROUNDS = new NonTerminal("BACKGROUNDS");
            var BACKGROUND = new NonTerminal("BACKGROUND");
            var BODIESBACKGROUND = new NonTerminal("BODIESBACKGROUND");
            var BODYBACKGROUND = new NonTerminal("BODYBACKGROUND");
            var LABELFIGURE = new NonTerminal("LABELFIGURE");
            var FIGURES = new NonTerminal("FIGURES");
            var FIGURE = new NonTerminal("FIGURE");
            var FIGUREBODIES = new NonTerminal("FIGUREBODIES");
            var FIGUREBODY = new NonTerminal("FIGUREBODY");
            var LABELDESIGN = new NonTerminal("LABELDESIGN");
            var FIGURETYPE = new NonTerminal("FIGURETYPE");
            var FTYPE = new NonTerminal("FTYPE");
            var NAME = new NonTerminal("NAME");
            var SOURCE = new NonTerminal("SOURCE");
            var DESCRIPTION = new NonTerminal("DESCRIPTION");
            var LIFE = new NonTerminal("LIFE");
            var DESTRUCTION = new NonTerminal("DESTRUCTION");
            var HERO = new NonTerminal("HERO");
            //var HEROS=new NonTerminal("HEROS");
            var HEROBODIES = new NonTerminal("HEROBODIES");
            var HEROBODY = new NonTerminal("HEROBODY");
            var HEROTYPE = new NonTerminal("HEROTYPE");
            var ENEMY = new NonTerminal("ENEMY");
            //var ENEMIES = new NonTerminal("ENEMYS");
            var ENEMYBODIES = new NonTerminal("ENEMYBODIES");
            var ENEMYBODY = new NonTerminal("ENEMYBODY");
            var ENEMYTYPE = new NonTerminal("ENEMYTYPE");
            var DESIGN = new NonTerminal("DESIGN");
            var DESIGNS = new NonTerminal("DESIGNS");
            var DESIGNBODIES = new NonTerminal("DESIGNBODIES");
            var DESIGNBODY = new NonTerminal("DESIGNBODY");
            var DESIGNTYPE = new NonTerminal("DESIGNTYPE");
            var DTYPE = new NonTerminal("DTYPE");
            var FINISH = new NonTerminal("FINISH");
            var FINISHTYPE = new NonTerminal("FINISHTYPE");
            var BLOCK = new NonTerminal("BLOCK");
            var BLOCKTYPE = new NonTerminal("BLOCKTYPE");
            var BONUS = new NonTerminal("BONUS");
            var BONUSTYPE = new NonTerminal("BONUSTYPE");
            //var BOMB = new NonTerminal("BOMB");
            var POINTS = new NonTerminal("POINTS");
            var WEAPON = new NonTerminal("WEAPON");
            var WEAPONTYPE = new NonTerminal("WEAPONTYPE");
            var WTYPE = new NonTerminal("TYPE");
            var EXP = new NonTerminal("EXP");
            
            
            
            

            #endregion

            #region GRAMATICA

            START.Rule = tokMenor + tokConfig + tokMayor + BODIES + tokMenor + tokSlash + tokConfig + tokMayor
                            ;

            BODIES.Rule = MakePlusRule(BODIES, BODY)
                            ;

            BODY.Rule = LABELBACKGROUND
                            | LABELFIGURE
                            | LABELDESIGN
                            ;
            BODY.ErrorRule = SyntaxError + ">";
            
            LABELBACKGROUND.Rule = tokMenor + tokBackground + tokMayor + BACKGROUNDS + tokMenor + tokSlash + tokBackground + tokMayor
                            ;

            LABELFIGURE.Rule = tokMenor + tokFigure + tokMayor + FIGURES + tokMenor + tokSlash + tokFigure + tokMayor
                            ;

            LABELDESIGN.Rule = tokMenor + tokDesign + tokMayor + DESIGNS + tokMenor + tokSlash + tokDesign + tokMayor
                            ;

            BACKGROUNDS.Rule = MakePlusRule(BACKGROUNDS, tokComa, BACKGROUND)
                            ;

            BACKGROUND.Rule = tokAllave + BODIESBACKGROUND + tokCllave
                            ;
            BACKGROUND.ErrorRule = SyntaxError + "}";

            BODIESBACKGROUND.Rule = MakeStarRule(BODIESBACKGROUND, BODYBACKGROUND)
                            ;

            BODYBACKGROUND.Rule = NAME
                            | SOURCE
                            ;

            NAME.Rule = tokNombre + tokIgual + tokId + tokPcoma
                            ;
            NAME.ErrorRule = SyntaxError + ";";

            SOURCE.Rule = tokImagen + tokIgual + tokCadena + tokPcoma
                            ;
            SOURCE.ErrorRule = SyntaxError + ";";

            DESCRIPTION.Rule = tokDescripcion + tokIgual + tokCadena + tokPcoma
                            ;
            DESCRIPTION.ErrorRule = SyntaxError + ";";

            LIFE.Rule = tokVida + tokIgual + EXP + tokPcoma
                            ;
            LIFE.ErrorRule = SyntaxError + ";";

            DESTRUCTION.Rule = tokDestruir + tokIgual + EXP + tokPcoma
                           ;
            DESTRUCTION.ErrorRule = SyntaxError + ";";


            FIGURES.Rule = MakePlusRule(FIGURES, tokComa, FIGURE)
                            ;

            FIGURE.Rule = tokAllave + FIGUREBODIES + tokCllave
                            ;
            FIGURE.ErrorRule = SyntaxError + "}";

            FIGUREBODIES.Rule = MakePlusRule(FIGUREBODIES, FIGUREBODY)
                            ;

            FIGUREBODY.Rule = NAME
                            | SOURCE
                            | LIFE
                            | DESCRIPTION
                            | DESTRUCTION
                            | FIGURETYPE
                            ;

            FIGURETYPE.Rule = tokTipo + tokIgual + FTYPE + tokPcoma
                            ;
            FIGURETYPE.ErrorRule = SyntaxError + ";";

            FTYPE.Rule = tokHero
                        | tokEnemy
                        ;

            EXP.Rule = EXP + tokMas + EXP
                            | EXP + tokMenos + EXP
                            | EXP + tokPor + EXP
                            | EXP + tokDiv + EXP
                            | tokNumero
                            | tokApar + EXP + tokCpar
                            | tokMenos + EXP
                            ;

            DESIGNS.Rule = MakePlusRule(DESIGNS, tokComa, DESIGN)
                            ;

            DESIGN.Rule = tokAllave + DESIGNBODIES + tokCllave
                            ;
            DESIGN.ErrorRule = SyntaxError + "}";

            DESIGNBODIES.Rule = MakePlusRule(DESIGNBODIES, DESIGNBODY)
                            ;

            DESIGNBODY.Rule = NAME
                            | SOURCE
                            | POINTS
                            | DESTRUCTION
                            | DESIGNTYPE
                            ;

            POINTS.Rule = tokCreditos + tokIgual + EXP + tokPcoma
                            ;
            POINTS.ErrorRule = SyntaxError + ";";

            DESIGNTYPE.Rule = tokTipo + tokIgual + DTYPE + tokPcoma
                            ;
            DESIGNTYPE.ErrorRule = SyntaxError + ";";

            DTYPE.Rule = tokMeta
                            | tokBloque
                            | tokBonus
                            | tokBomba
                            | tokArma
                            ;

            RegisterOperators(1, Associativity.Left, tokMas, tokMenos);
            RegisterOperators(2, Associativity.Left, tokPor, tokDiv);
            RegisterOperators(3, "-()");
            RegisterOperators(4, tokApar + tokCpar);

            this.MarkPunctuation(";","<",">","/","{","}","configuration", "figure", "background", "design","(",")");
            this.MarkTransient(BACKGROUND, BODYBACKGROUND, FIGUREBODY, DESIGNBODY, FTYPE, DTYPE, BODY, FIGURE, DESIGN, LABELBACKGROUND, LABELDESIGN, LABELFIGURE);

            this.Root = START;
            #endregion
        }
    }
}
