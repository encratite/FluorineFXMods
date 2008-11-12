// $ANTLR 2.7.6 (2005-12-22): "sql.g" -> "SQLParser.cs"$

namespace FluorineFx.ServiceBrowser.Sql
{
	// Generate the header common to all output files.
	using System;
	
	using TokenBuffer              = antlr.TokenBuffer;
	using TokenStreamException     = antlr.TokenStreamException;
	using TokenStreamIOException   = antlr.TokenStreamIOException;
	using ANTLRException           = antlr.ANTLRException;
	using LLkParser = antlr.LLkParser;
	using Token                    = antlr.Token;
	using IToken                   = antlr.IToken;
	using TokenStream              = antlr.TokenStream;
	using RecognitionException     = antlr.RecognitionException;
	using NoViableAltException     = antlr.NoViableAltException;
	using MismatchedTokenException = antlr.MismatchedTokenException;
	using SemanticException        = antlr.SemanticException;
	using ParserSharedInputState   = antlr.ParserSharedInputState;
	using BitSet                   = antlr.collections.impl.BitSet;
	using AST                      = antlr.collections.AST;
	using ASTPair                  = antlr.ASTPair;
	using ASTFactory               = antlr.ASTFactory;
	using ASTArray                 = antlr.collections.impl.ASTArray;
	
//  Class preamble starts here - right before the class definition in the generated class file
using FluorineFx.Management.Data;

//#pragma warning disable 219, 162
//  Class preamble ends here

	internal 	class SQLParser : antlr.LLkParser
	{
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int SQL2NRW_ada = 5;
		public const int SQL2NRW_c = 6;
		public const int SQL2NRW_catalog_name = 7;
		public const int SQL2NRW_character_set_catalog = 8;
		public const int SQL2NRW_character_set_name = 9;
		public const int SQL2NRW_character_set_schema = 10;
		public const int SQL2NRW_class_origin = 11;
		public const int SQL2NRW_cobol = 12;
		public const int SQL2NRW_collation_catalog = 13;
		public const int SQL2NRW_collation_name = 14;
		public const int SQL2NRW_collation_schema = 15;
		public const int SQL2NRW_column_name = 16;
		public const int SQL2NRW_command_function = 17;
		public const int SQL2NRW_committed = 18;
		public const int SQL2NRW_condition_number = 19;
		public const int SQL2NRW_connection_name = 20;
		public const int SQL2NRW_constraint_catalog = 21;
		public const int SQL2NRW_constraint_name = 22;
		public const int SQL2NRW_constraint_schema = 23;
		public const int SQL2NRW_cursor_name = 24;
		public const int SQL2NRW_data = 25;
		public const int SQL2NRW_datetime_interval_code = 26;
		public const int SQL2NRW_datetime_interval_precision = 27;
		public const int SQL2NRW_dynamic_function = 28;
		public const int SQL2NRW_fortran = 29;
		public const int SQL2NRW_length = 30;
		public const int SQL2NRW_message_length = 31;
		public const int SQL2NRW_message_octet_length = 32;
		public const int SQL2NRW_message_text = 33;
		public const int SQL2NRW_more = 34;
		public const int SQL2NRW_mumps = 35;
		public const int SQL2NRW_name = 36;
		public const int SQL2NRW_nullable = 37;
		public const int SQL2NRW_number = 38;
		public const int SQL2NRW_pascal = 39;
		public const int SQL2NRW_pli = 40;
		public const int SQL2NRW_repeatable = 41;
		public const int SQL2NRW_returned_length = 42;
		public const int SQL2NRW_returned_octet_length = 43;
		public const int SQL2NRW_returned_sqlstate = 44;
		public const int SQL2NRW_row_count = 45;
		public const int SQL2NRW_scale = 46;
		public const int SQL2NRW_schema_name = 47;
		public const int SQL2NRW_serializable = 48;
		public const int SQL2NRW_server_name = 49;
		public const int SQL2NRW_subclass_origin = 50;
		public const int SQL2NRW_table_name = 51;
		public const int SQL2NRW_type = 52;
		public const int SQL2NRW_uncommitted = 53;
		public const int SQL2NRW_unnamed = 54;
		public const int SQL2RW_absolute = 55;
		public const int SQL2RW_action = 56;
		public const int SQL2RW_add = 57;
		public const int SQL2RW_all = 58;
		public const int SQL2RW_allocate = 59;
		public const int SQL2RW_alter = 60;
		public const int SQL2RW_and = 61;
		public const int SQL2RW_any = 62;
		public const int SQL2RW_are = 63;
		public const int SQL2RW_as = 64;
		public const int SQL2RW_asc = 65;
		public const int SQL2RW_assertion = 66;
		public const int SQL2RW_at = 67;
		public const int SQL2RW_authorization = 68;
		public const int SQL2RW_avg = 69;
		public const int SQL2RW_begin = 70;
		public const int SQL2RW_between = 71;
		public const int SQL2RW_bit = 72;
		public const int SQL2RW_bit_length = 73;
		public const int SQL2RW_both = 74;
		public const int SQL2RW_by = 75;
		public const int SQL2RW_cascade = 76;
		public const int SQL2RW_cascaded = 77;
		public const int SQL2RW_case = 78;
		public const int SQL2RW_cast = 79;
		public const int SQL2RW_catalog = 80;
		public const int SQL2RW_char = 81;
		public const int SQL2RW_character = 82;
		public const int SQL2RW_char_length = 83;
		public const int SQL2RW_character_length = 84;
		public const int SQL2RW_check = 85;
		public const int SQL2RW_close = 86;
		public const int SQL2RW_coalesce = 87;
		public const int SQL2RW_collate = 88;
		public const int SQL2RW_collation = 89;
		public const int SQL2RW_column = 90;
		public const int SQL2RW_commit = 91;
		public const int SQL2RW_connect = 92;
		public const int SQL2RW_connection = 93;
		public const int SQL2RW_constraint = 94;
		public const int SQL2RW_constraints = 95;
		public const int SQL2RW_continue = 96;
		public const int SQL2RW_convert = 97;
		public const int SQL2RW_corresponding = 98;
		public const int SQL2RW_count = 99;
		public const int SQL2RW_create = 100;
		public const int SQL2RW_cross = 101;
		public const int SQL2RW_current = 102;
		public const int SQL2RW_current_date = 103;
		public const int SQL2RW_current_time = 104;
		public const int SQL2RW_current_timestamp = 105;
		public const int SQL2RW_current_user = 106;
		public const int SQL2RW_cursor = 107;
		public const int SQL2RW_date = 108;
		public const int SQL2RW_day = 109;
		public const int SQL2RW_deallocate = 110;
		public const int SQL2RW_dec = 111;
		public const int SQL2RW_decimal = 112;
		public const int SQL2RW_declare = 113;
		public const int SQL2RW_default = 114;
		public const int SQL2RW_deferrable = 115;
		public const int SQL2RW_deferred = 116;
		public const int SQL2RW_delete = 117;
		public const int SQL2RW_desc = 118;
		public const int SQL2RW_describe = 119;
		public const int SQL2RW_descriptor = 120;
		public const int SQL2RW_diagnostics = 121;
		public const int SQL2RW_disconnect = 122;
		public const int SQL2RW_distinct = 123;
		public const int SQL2RW_domain = 124;
		public const int SQL2RW_double = 125;
		public const int SQL2RW_drop = 126;
		public const int SQL2RW_else = 127;
		public const int SQL2RW_end = 128;
		public const int SQL2RW_end_exec = 129;
		public const int SQL2RW_escape = 130;
		public const int SQL2RW_except = 131;
		public const int SQL2RW_exception = 132;
		public const int SQL2RW_exec = 133;
		public const int SQL2RW_execute = 134;
		public const int SQL2RW_exists = 135;
		public const int SQL2RW_external = 136;
		public const int SQL2RW_extract = 137;
		public const int SQL2RW_false = 138;
		public const int SQL2RW_fetch = 139;
		public const int SQL2RW_first = 140;
		public const int SQL2RW_float = 141;
		public const int SQL2RW_for = 142;
		public const int SQL2RW_foreign = 143;
		public const int SQL2RW_found = 144;
		public const int SQL2RW_from = 145;
		public const int SQL2RW_full = 146;
		public const int SQL2RW_get = 147;
		public const int SQL2RW_global = 148;
		public const int SQL2RW_go = 149;
		public const int SQL2RW_goto = 150;
		public const int SQL2RW_grant = 151;
		public const int SQL2RW_group = 152;
		public const int SQL2RW_having = 153;
		public const int SQL2RW_hour = 154;
		public const int SQL2RW_identity = 155;
		public const int SQL2RW_immediate = 156;
		public const int SQL2RW_in = 157;
		public const int SQL2RW_indicator = 158;
		public const int SQL2RW_initially = 159;
		public const int SQL2RW_inner = 160;
		public const int SQL2RW_input = 161;
		public const int SQL2RW_insensitive = 162;
		public const int SQL2RW_insert = 163;
		public const int SQL2RW_int = 164;
		public const int SQL2RW_integer = 165;
		public const int SQL2RW_intersect = 166;
		public const int SQL2RW_interval = 167;
		public const int SQL2RW_into = 168;
		public const int SQL2RW_is = 169;
		public const int SQL2RW_isolation = 170;
		public const int SQL2RW_join = 171;
		public const int SQL2RW_key = 172;
		public const int SQL2RW_language = 173;
		public const int SQL2RW_last = 174;
		public const int SQL2RW_leading = 175;
		public const int SQL2RW_left = 176;
		public const int SQL2RW_level = 177;
		public const int SQL2RW_like = 178;
		public const int SQL2RW_local = 179;
		public const int SQL2RW_lower = 180;
		public const int SQL2RW_match = 181;
		public const int SQL2RW_max = 182;
		public const int SQL2RW_min = 183;
		public const int SQL2RW_minute = 184;
		public const int SQL2RW_module = 185;
		public const int SQL2RW_month = 186;
		public const int SQL2RW_names = 187;
		public const int SQL2RW_national = 188;
		public const int SQL2RW_natural = 189;
		public const int SQL2RW_nchar = 190;
		public const int SQL2RW_next = 191;
		public const int SQL2RW_no = 192;
		public const int SQL2RW_not = 193;
		public const int SQL2RW_null = 194;
		public const int SQL2RW_nullif = 195;
		public const int SQL2RW_numeric = 196;
		public const int SQL2RW_octet_length = 197;
		public const int SQL2RW_of = 198;
		public const int SQL2RW_on = 199;
		public const int SQL2RW_only = 200;
		public const int SQL2RW_open = 201;
		public const int SQL2RW_option = 202;
		public const int SQL2RW_or = 203;
		public const int SQL2RW_order = 204;
		public const int SQL2RW_outer = 205;
		public const int SQL2RW_output = 206;
		public const int SQL2RW_overlaps = 207;
		public const int SQL2RW_pad = 208;
		public const int SQL2RW_partial = 209;
		public const int SQL2RW_position = 210;
		public const int SQL2RW_precision = 211;
		public const int SQL2RW_prepare = 212;
		public const int SQL2RW_preserve = 213;
		public const int SQL2RW_primary = 214;
		public const int SQL2RW_prior = 215;
		public const int SQL2RW_privileges = 216;
		public const int SQL2RW_procedure = 217;
		public const int SQL2RW_public = 218;
		public const int SQL2RW_read = 219;
		public const int SQL2RW_real = 220;
		public const int SQL2RW_references = 221;
		public const int SQL2RW_relative = 222;
		public const int SQL2RW_restrict = 223;
		public const int SQL2RW_revoke = 224;
		public const int SQL2RW_right = 225;
		public const int SQL2RW_rollback = 226;
		public const int SQL2RW_rows = 227;
		public const int SQL2RW_schema = 228;
		public const int SQL2RW_scroll = 229;
		public const int SQL2RW_second = 230;
		public const int SQL2RW_section = 231;
		public const int SQL2RW_select = 232;
		public const int SQL2RW_session = 233;
		public const int SQL2RW_session_user = 234;
		public const int SQL2RW_set = 235;
		public const int SQL2RW_size = 236;
		public const int SQL2RW_smallint = 237;
		public const int SQL2RW_some = 238;
		public const int SQL2RW_space = 239;
		public const int SQL2RW_sql = 240;
		public const int SQL2RW_sqlcode = 241;
		public const int SQL2RW_sqlerror = 242;
		public const int SQL2RW_sqlstate = 243;
		public const int SQL2RW_substring = 244;
		public const int SQL2RW_sum = 245;
		public const int SQL2RW_system_user = 246;
		public const int SQL2RW_table = 247;
		public const int SQL2RW_temporary = 248;
		public const int SQL2RW_then = 249;
		public const int SQL2RW_time = 250;
		public const int SQL2RW_timestamp = 251;
		public const int SQL2RW_timezone_hour = 252;
		public const int SQL2RW_timezone_minute = 253;
		public const int SQL2RW_to = 254;
		public const int SQL2RW_trailing = 255;
		public const int SQL2RW_transaction = 256;
		public const int SQL2RW_translate = 257;
		public const int SQL2RW_translation = 258;
		public const int SQL2RW_trim = 259;
		public const int SQL2RW_true = 260;
		public const int SQL2RW_union = 261;
		public const int SQL2RW_unique = 262;
		public const int SQL2RW_unknown = 263;
		public const int SQL2RW_update = 264;
		public const int SQL2RW_upper = 265;
		public const int SQL2RW_usage = 266;
		public const int SQL2RW_user = 267;
		public const int SQL2RW_using = 268;
		public const int SQL2RW_value = 269;
		public const int SQL2RW_values = 270;
		public const int SQL2RW_varchar = 271;
		public const int SQL2RW_varying = 272;
		public const int SQL2RW_view = 273;
		public const int SQL2RW_when = 274;
		public const int SQL2RW_whenever = 275;
		public const int SQL2RW_where = 276;
		public const int SQL2RW_with = 277;
		public const int SQL2RW_work = 278;
		public const int SQL2RW_write = 279;
		public const int SQL2RW_year = 280;
		public const int SQL2RW_zone = 281;
		public const int UNSIGNED_INTEGER = 282;
		public const int APPROXIMATE_NUM_LIT = 283;
		public const int QUOTE = 284;
		public const int PERIOD = 285;
		public const int MINUS_SIGN = 286;
		public const int UNDERSCORE = 287;
		public const int DOUBLE_PERIOD = 288;
		public const int NOT_EQUALS_OP = 289;
		public const int LESS_THAN_OR_EQUALS_OP = 290;
		public const int GREATER_THAN_OR_EQUALS_OP = 291;
		public const int CONCATENATION_OP = 292;
		public const int NATIONAL_CHAR_STRING_LIT = 293;
		public const int BIT_STRING_LIT = 294;
		public const int HEX_STRING_LIT = 295;
		public const int EMBDD_VARIABLE_NAME = 296;
		public const int REGULAR_ID = 297;
		public const int EXACT_NUM_LIT = 298;
		public const int CHAR_STRING = 299;
		public const int DELIMITED_ID = 300;
		public const int PERCENT = 301;
		public const int AMPERSAND = 302;
		public const int LEFT_PAREN = 303;
		public const int RIGHT_PAREN = 304;
		public const int ASTERISK = 305;
		public const int PLUS_SIGN = 306;
		public const int COMMA = 307;
		public const int SOLIDUS = 308;
		public const int COLON = 309;
		public const int SEMICOLON = 310;
		public const int LESS_THAN_OP = 311;
		public const int EQUALS_OP = 312;
		public const int GREATER_THAN_OP = 313;
		public const int QUESTION_MARK = 314;
		public const int VERTICAL_BAR = 315;
		public const int LEFT_BRACKET = 316;
		public const int RIGHT_BRACKET = 317;
		public const int INTRODUCER = 318;
		public const int SIMPLE_LETTER = 319;
		public const int SEPARATOR = 320;
		public const int COMMENT = 321;
		public const int NEWLINE = 322;
		public const int SPACE = 323;
		public const int ANY_CHAR = 324;
		public const int DOUBLE_QUOTE = 325;
		public const int DOLLAR_SIGN = 326;
		
		
//  Class body inset starts here - at the top within the generated class body

//  Class body inset ends here
		
		protected void initialize()
		{
			tokenNames = tokenNames_;
			initializeFactory();
		}
		
		
		protected SQLParser(TokenBuffer tokenBuf, int k) : base(tokenBuf, k)
		{
			initialize();
		}
		
		public SQLParser(TokenBuffer tokenBuf) : this(tokenBuf,2)
		{
		}
		
		protected SQLParser(TokenStream lexer, int k) : base(lexer,k)
		{
			initialize();
		}
		
		public SQLParser(TokenStream lexer) : this(lexer,2)
		{
		}
		
		public SQLParser(ParserSharedInputState state) : base(state,2)
		{
			initialize();
		}
		
	public void any_token() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST any_token_AST = null;
		
		matchNot(EOF);
		returnAST = any_token_AST;
	}
	
	public void sql_script(
		ISqlScript sqlScript
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sql_script_AST = null;
		
		{
			if ((tokenSet_0_.member(LA(1))))
			{
				sql_stmt(sqlScript);
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==SEMICOLON))
				{
					AST tmp2_AST = null;
					tmp2_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp2_AST);
					match(SEMICOLON);
					{
						if ((tokenSet_0_.member(LA(1))))
						{
							sql_stmt(sqlScript);
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
				}
				else
				{
					goto _loop101_breakloop;
				}
				
			}
_loop101_breakloop:			;
		}    // ( ... )*
		sql_script_AST = currentAST.root;
		returnAST = sql_script_AST;
	}
	
	public void sql_stmt(
		ISqlScript sqlScript
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sql_stmt_AST = null;
		
		sql_data_stmt(sqlScript);
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		sql_stmt_AST = currentAST.root;
		returnAST = sql_stmt_AST;
	}
	
	public void sql_single_stmt(
		ISqlScript sqlScript
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sql_single_stmt_AST = null;
		
		{
			if ((tokenSet_0_.member(LA(1))))
			{
				sql_stmt(sqlScript);
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==SEMICOLON))
			{
				AST tmp3_AST = null;
				tmp3_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp3_AST);
				match(SEMICOLON);
			}
			else if ((LA(1)==EOF)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		sql_single_stmt_AST = currentAST.root;
		returnAST = sql_single_stmt_AST;
	}
	
	public void sql_data_stmt(
		ISqlScript sqlScript
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sql_data_stmt_AST = null;
		ISqlStatement sqlStatement;
		
		switch ( LA(1) )
		{
		case SQL2NRW_ada:
		case SQL2RW_module:
		case SQL2RW_select:
		case SQL2RW_table:
		case SQL2RW_values:
		case REGULAR_ID:
		case DELIMITED_ID:
		case LEFT_PAREN:
		case INTRODUCER:
		{
			sqlStatement=select_stmt();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
						sqlScript.AddStatement(sqlStatement);
					
			}
			sql_data_stmt_AST = currentAST.root;
			break;
		}
		case SQL2RW_insert:
		{
			insert_stmt();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			sql_data_stmt_AST = currentAST.root;
			break;
		}
		case SQL2RW_update:
		{
			update_stmt();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			sql_data_stmt_AST = currentAST.root;
			break;
		}
		case SQL2RW_delete:
		{
			delete_stmt();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			sql_data_stmt_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = sql_data_stmt_AST;
	}
	
	public ISelectStatement  select_stmt() //throws RecognitionException, TokenStreamException
{
		ISelectStatement selectStatement;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST select_stmt_AST = null;
		
			selectStatement = new SelectStatement();
			IQueryExpression queryExpression = null;
		
		
		queryExpression=query_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			
					selectStatement.QueryExpression = queryExpression;
				
		}
		{
			switch ( LA(1) )
			{
			case SQL2RW_into:
			{
				into_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==SQL2RW_order))
					{
						order_by_clause(selectStatement);
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==EOF||LA(1)==SQL2RW_for||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				{
					if ((LA(1)==SQL2RW_for))
					{
						updatability_clause();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				break;
			}
			case SQL2RW_order:
			{
				order_by_clause(selectStatement);
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==SQL2RW_into))
					{
						into_clause();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==EOF||LA(1)==SQL2RW_for||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				{
					if ((LA(1)==SQL2RW_for))
					{
						updatability_clause();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				break;
			}
			case SQL2RW_for:
			{
				updatability_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==SQL2RW_into))
					{
						into_clause();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				break;
			}
			case EOF:
			case SEMICOLON:
			{
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		select_stmt_AST = currentAST.root;
		returnAST = select_stmt_AST;
		return selectStatement;
	}
	
	public void insert_stmt() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST insert_stmt_AST = null;
		
		AST tmp4_AST = null;
		tmp4_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp4_AST);
		match(SQL2RW_insert);
		AST tmp5_AST = null;
		tmp5_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp5_AST);
		match(SQL2RW_into);
		table_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		insert_columns_and_source();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		insert_stmt_AST = currentAST.root;
		returnAST = insert_stmt_AST;
	}
	
	public void update_stmt() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST update_stmt_AST = null;
		
		AST tmp6_AST = null;
		tmp6_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp6_AST);
		match(SQL2RW_update);
		{
			if ((LA(1)==SQL2NRW_ada||LA(1)==SQL2RW_module||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
			{
				table_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp7_AST = null;
				tmp7_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp7_AST);
				match(SQL2RW_set);
				set_clause_list();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==SQL2RW_where))
					{
						AST tmp8_AST = null;
						tmp8_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp8_AST);
						match(SQL2RW_where);
						{
							if ((tokenSet_1_.member(LA(1))))
							{
								search_condition();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
							}
							else if ((LA(1)==SQL2RW_current)) {
								AST tmp9_AST = null;
								tmp9_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp9_AST);
								match(SQL2RW_current);
								AST tmp10_AST = null;
								tmp10_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp10_AST);
								match(SQL2RW_of);
								dyn_cursor_name();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
							}
							else
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							
						}
					}
					else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else if ((LA(1)==SQL2RW_set)) {
				AST tmp11_AST = null;
				tmp11_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp11_AST);
				match(SQL2RW_set);
				set_clause_list();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp12_AST = null;
				tmp12_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp12_AST);
				match(SQL2RW_where);
				AST tmp13_AST = null;
				tmp13_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp13_AST);
				match(SQL2RW_current);
				AST tmp14_AST = null;
				tmp14_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp14_AST);
				match(SQL2RW_of);
				cursor_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		update_stmt_AST = currentAST.root;
		returnAST = update_stmt_AST;
	}
	
	public void delete_stmt() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST delete_stmt_AST = null;
		
		AST tmp15_AST = null;
		tmp15_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp15_AST);
		match(SQL2RW_delete);
		{
			if ((LA(1)==SQL2RW_from))
			{
				AST tmp16_AST = null;
				tmp16_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp16_AST);
				match(SQL2RW_from);
				table_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==SQL2RW_where))
					{
						AST tmp17_AST = null;
						tmp17_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp17_AST);
						match(SQL2RW_where);
						{
							if ((tokenSet_1_.member(LA(1))))
							{
								search_condition();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
							}
							else if ((LA(1)==SQL2RW_current)) {
								AST tmp18_AST = null;
								tmp18_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp18_AST);
								match(SQL2RW_current);
								AST tmp19_AST = null;
								tmp19_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp19_AST);
								match(SQL2RW_of);
								dyn_cursor_name();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
							}
							else
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							
						}
					}
					else if ((LA(1)==EOF||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else if ((LA(1)==SQL2RW_where)) {
				AST tmp20_AST = null;
				tmp20_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp20_AST);
				match(SQL2RW_where);
				AST tmp21_AST = null;
				tmp21_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp21_AST);
				match(SQL2RW_current);
				AST tmp22_AST = null;
				tmp22_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp22_AST);
				match(SQL2RW_of);
				cursor_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		delete_stmt_AST = currentAST.root;
		returnAST = delete_stmt_AST;
	}
	
	public IQueryExpression  query_exp() //throws RecognitionException, TokenStreamException
{
		IQueryExpression queryExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST query_exp_AST = null;
		
			IQueryExpression queryExpression2;
			CombineOperation op = CombineOperation.Union;
			bool all = false; bool corresponding = false;
		
		
		queryExpression=query_term();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==SQL2RW_except||LA(1)==SQL2RW_union))
				{
					{
						if ((LA(1)==SQL2RW_union))
						{
							AST tmp23_AST = null;
							tmp23_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp23_AST);
							match(SQL2RW_union);
							if (0==inputState.guessing)
							{
								op = CombineOperation.Union;
							}
						}
						else if ((LA(1)==SQL2RW_except)) {
							AST tmp24_AST = null;
							tmp24_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp24_AST);
							match(SQL2RW_except);
							if (0==inputState.guessing)
							{
								op = CombineOperation.Except;
							}
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					if (0==inputState.guessing)
					{
						
										all = false;
										corresponding = false;
									
					}
					{
						if ((LA(1)==SQL2RW_all))
						{
							AST tmp25_AST = null;
							tmp25_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp25_AST);
							match(SQL2RW_all);
							if (0==inputState.guessing)
							{
								all = true;
							}
						}
						else if ((tokenSet_2_.member(LA(1)))) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					{
						if ((LA(1)==SQL2RW_corresponding))
						{
							corresponding_spec();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							if (0==inputState.guessing)
							{
								corresponding = true;
							}
						}
						else if ((tokenSet_3_.member(LA(1)))) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					queryExpression2=query_term();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
									IQueryExpression queryExpression1 = queryExpression;
									ISetCombinationExpression setCombinationExpression = new SetCombinationExpression();
									setCombinationExpression.Operator = op;
									setCombinationExpression.All = all;
									setCombinationExpression.Corresponding = corresponding;
									setCombinationExpression.Expression1 = queryExpression1;
									setCombinationExpression.Expression2 = queryExpression2;
									queryExpression = setCombinationExpression;
								
					}
				}
				else
				{
					goto _loop280_breakloop;
				}
				
			}
_loop280_breakloop:			;
		}    // ( ... )*
		query_exp_AST = currentAST.root;
		returnAST = query_exp_AST;
		return queryExpression;
	}
	
	public void into_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST into_clause_AST = null;
		
		AST tmp26_AST = null;
		tmp26_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp26_AST);
		match(SQL2RW_into);
		target_spec();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp27_AST = null;
					tmp27_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp27_AST);
					match(COMMA);
					target_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop116_breakloop;
				}
				
			}
_loop116_breakloop:			;
		}    // ( ... )*
		into_clause_AST = currentAST.root;
		returnAST = into_clause_AST;
	}
	
	public void order_by_clause(
		ISelectStatement selectStatement
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST order_by_clause_AST = null;
		
		AST tmp28_AST = null;
		tmp28_AST = astFactory.create(LT(1));
		astFactory.makeASTRoot(ref currentAST, tmp28_AST);
		match(SQL2RW_order);
		AST tmp29_AST = null;
		tmp29_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp29_AST);
		match(SQL2RW_by);
		sort_spec_list(selectStatement);
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		order_by_clause_AST = currentAST.root;
		returnAST = order_by_clause_AST;
	}
	
	public void updatability_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST updatability_clause_AST = null;
		
		AST tmp30_AST = null;
		tmp30_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp30_AST);
		match(SQL2RW_for);
		{
			if ((LA(1)==SQL2RW_read))
			{
				AST tmp31_AST = null;
				tmp31_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp31_AST);
				match(SQL2RW_read);
				AST tmp32_AST = null;
				tmp32_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp32_AST);
				match(SQL2RW_only);
			}
			else if ((LA(1)==SQL2RW_update)) {
				AST tmp33_AST = null;
				tmp33_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp33_AST);
				match(SQL2RW_update);
				{
					if ((LA(1)==SQL2RW_of))
					{
						AST tmp34_AST = null;
						tmp34_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp34_AST);
						match(SQL2RW_of);
						column_name_list();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==EOF||LA(1)==SQL2RW_into||LA(1)==SEMICOLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		updatability_clause_AST = currentAST.root;
		returnAST = updatability_clause_AST;
	}
	
	public void target_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST target_spec_AST = null;
		
		if ((LA(1)==COLON))
		{
			parameter_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			target_spec_AST = currentAST.root;
		}
		else if ((LA(1)==EMBDD_VARIABLE_NAME)) {
			variable_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			target_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = target_spec_AST;
	}
	
	public void sort_spec_list(
		ISelectStatement selectStatement
	) //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sort_spec_list_AST = null;
		
			IOrderBySortSpec orderBySortSpec;
		
		
		orderBySortSpec=sort_spec();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			
					selectStatement.AddSortSpec(orderBySortSpec);
				
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp35_AST = null;
					tmp35_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp35_AST);
					match(COMMA);
					orderBySortSpec=sort_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
									selectStatement.AddSortSpec(orderBySortSpec);
								
					}
				}
				else
				{
					goto _loop120_breakloop;
				}
				
			}
_loop120_breakloop:			;
		}    // ( ... )*
		sort_spec_list_AST = currentAST.root;
		returnAST = sort_spec_list_AST;
	}
	
	public IOrderBySortSpec  sort_spec() //throws RecognitionException, TokenStreamException
{
		IOrderBySortSpec orderBySortSpec;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sort_spec_AST = null;
		
			orderBySortSpec = new OrderBySortSpec();
			string sortKey = null;
			SortKind sortKind = SortKind.Ascending;
		
		
		sortKey=sort_key();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			
					orderBySortSpec.SortKey = sortKey;
				
		}
		{
			if ((LA(1)==SQL2RW_collate))
			{
				collate_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==EOF||LA(1)==SQL2RW_asc||LA(1)==SQL2RW_desc||LA(1)==SQL2RW_for||LA(1)==SQL2RW_into||LA(1)==COMMA||LA(1)==SEMICOLON)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==SQL2RW_asc||LA(1)==SQL2RW_desc))
			{
				sortKind=ordering_spec();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					orderBySortSpec.SortKind = sortKind;
				}
			}
			else if ((LA(1)==EOF||LA(1)==SQL2RW_for||LA(1)==SQL2RW_into||LA(1)==COMMA||LA(1)==SEMICOLON)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		sort_spec_AST = currentAST.root;
		returnAST = sort_spec_AST;
		return orderBySortSpec;
	}
	
	public string  sort_key() //throws RecognitionException, TokenStreamException
{
		string sortKey = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sort_key_AST = null;
		
		if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
		{
			sortKey=column_ref();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			sort_key_AST = currentAST.root;
		}
		else if ((LA(1)==UNSIGNED_INTEGER)) {
			AST tmp36_AST = null;
			tmp36_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp36_AST);
			match(UNSIGNED_INTEGER);
			sort_key_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = sort_key_AST;
		return sortKey;
	}
	
	public void collate_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST collate_clause_AST = null;
		
		AST tmp37_AST = null;
		tmp37_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp37_AST);
		match(SQL2RW_collate);
		collation_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		collate_clause_AST = currentAST.root;
		returnAST = collate_clause_AST;
	}
	
	public SortKind  ordering_spec() //throws RecognitionException, TokenStreamException
{
		 SortKind sortKind = SortKind.Ascending;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST ordering_spec_AST = null;
		
		if ((LA(1)==SQL2RW_asc))
		{
			AST tmp38_AST = null;
			tmp38_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp38_AST);
			match(SQL2RW_asc);
			if (0==inputState.guessing)
			{
				sortKind = SortKind.Ascending;
			}
			ordering_spec_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_desc)) {
			AST tmp39_AST = null;
			tmp39_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp39_AST);
			match(SQL2RW_desc);
			if (0==inputState.guessing)
			{
				sortKind = SortKind.Descending;
			}
			ordering_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = ordering_spec_AST;
		return sortKind;
	}
	
	public string  column_ref() //throws RecognitionException, TokenStreamException
{
		string columnName = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST column_ref_AST = null;
		
			string ident;
		
		
		ident=id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			columnName = ident;
		}
		{
			if ((LA(1)==PERIOD))
			{
				AST tmp40_AST = null;
				tmp40_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp40_AST);
				match(PERIOD);
				ident=id();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					columnName+="."; columnName+=ident;
				}
				{
					if ((LA(1)==PERIOD))
					{
						AST tmp41_AST = null;
						tmp41_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp41_AST);
						match(PERIOD);
						ident=id();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							columnName+="."; columnName+=ident;
						}
						{
							if ((LA(1)==PERIOD))
							{
								AST tmp42_AST = null;
								tmp42_AST = astFactory.create(LT(1));
								astFactory.addASTChild(ref currentAST, tmp42_AST);
								match(PERIOD);
								ident=id();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, returnAST);
								}
								if (0==inputState.guessing)
								{
									columnName+="."; columnName+=ident;
								}
							}
							else if ((tokenSet_4_.member(LA(1)))) {
							}
							else
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							
						}
					}
					else if ((tokenSet_4_.member(LA(1)))) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else if ((tokenSet_4_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		column_ref_AST = currentAST.root;
		returnAST = column_ref_AST;
		return columnName;
	}
	
	public void column_name_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST column_name_list_AST = null;
		
		column_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp43_AST = null;
					tmp43_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp43_AST);
					match(COMMA);
					column_name();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop411_breakloop;
				}
				
			}
_loop411_breakloop:			;
		}    // ( ... )*
		column_name_list_AST = currentAST.root;
		returnAST = column_name_list_AST;
	}
	
	public string  table_name() //throws RecognitionException, TokenStreamException
{
		 string tableName = null ;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_name_AST = null;
		
		if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
		{
			tableName=qualified_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			table_name_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_module)) {
			tableName=qualified_local_table_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			table_name_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = table_name_AST;
		return tableName;
	}
	
	public void insert_columns_and_source() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST insert_columns_and_source_AST = null;
		
		bool synPredMatched132 = false;
		if (((LA(1)==LEFT_PAREN) && (LA(2)==SQL2NRW_ada||LA(2)==REGULAR_ID||LA(2)==DELIMITED_ID||LA(2)==INTRODUCER)))
		{
			int _m132 = mark();
			synPredMatched132 = true;
			inputState.guessing++;
			try {
				{
					match(LEFT_PAREN);
					column_name_list();
					match(RIGHT_PAREN);
				}
			}
			catch (RecognitionException)
			{
				synPredMatched132 = false;
			}
			rewind(_m132);
			inputState.guessing--;
		}
		if ( synPredMatched132 )
		{
			AST tmp44_AST = null;
			tmp44_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp44_AST);
			match(LEFT_PAREN);
			column_name_list();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp45_AST = null;
			tmp45_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp45_AST);
			match(RIGHT_PAREN);
			query_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			insert_columns_and_source_AST = currentAST.root;
		}
		else if ((tokenSet_3_.member(LA(1))) && (tokenSet_5_.member(LA(2)))) {
			query_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			insert_columns_and_source_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_default)) {
			AST tmp46_AST = null;
			tmp46_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp46_AST);
			match(SQL2RW_default);
			AST tmp47_AST = null;
			tmp47_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp47_AST);
			match(SQL2RW_values);
			insert_columns_and_source_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = insert_columns_and_source_AST;
	}
	
	public void set_clause_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST set_clause_list_AST = null;
		
		set_clause();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp48_AST = null;
					tmp48_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp48_AST);
					match(COMMA);
					set_clause();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop139_breakloop;
				}
				
			}
_loop139_breakloop:			;
		}    // ( ... )*
		set_clause_list_AST = currentAST.root;
		returnAST = set_clause_list_AST;
	}
	
	public IExpression  search_condition() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST search_condition_AST = null;
		
			IExpression expressionRhs = null;
		
		
		expression=boolean_term();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==SQL2RW_or))
				{
					boolean_term_op();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					expressionRhs=boolean_term();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
									ITwoPartExpression twoPartExpression = new TwoPartExpression();
									twoPartExpression.Lhs = expression;
									twoPartExpression.Rhs = expressionRhs;
									twoPartExpression.Operator = SqlOperator.BooleanTermOperator;
									expression = twoPartExpression;
								
					}
				}
				else
				{
					goto _loop196_breakloop;
				}
				
			}
_loop196_breakloop:			;
		}    // ( ... )*
		search_condition_AST = currentAST.root;
		returnAST = search_condition_AST;
		return expression;
	}
	
	public void dyn_cursor_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST dyn_cursor_name_AST = null;
		
		if (((tokenSet_6_.member(LA(1))) && (tokenSet_7_.member(LA(2))))&&(LA(1) == INTRODUCER))
		{
			{
				bool synPredMatched417 = false;
				if (((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER) && (LA(2)==EOF||LA(2)==SQL2NRW_ada||LA(2)==REGULAR_ID||LA(2)==DELIMITED_ID||LA(2)==SEMICOLON||LA(2)==INTRODUCER)))
				{
					int _m417 = mark();
					synPredMatched417 = true;
					inputState.guessing++;
					try {
						{
							cursor_name();
						}
					}
					catch (RecognitionException)
					{
						synPredMatched417 = false;
					}
					rewind(_m417);
					inputState.guessing--;
				}
				if ( synPredMatched417 )
				{
					cursor_name();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((tokenSet_8_.member(LA(1))) && (tokenSet_7_.member(LA(2)))) {
					extended_cursor_name();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			dyn_cursor_name_AST = currentAST.root;
		}
		else if (((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER) && (LA(2)==EOF||LA(2)==SQL2NRW_ada||LA(2)==REGULAR_ID||LA(2)==DELIMITED_ID||LA(2)==SEMICOLON||LA(2)==INTRODUCER))&&(LA(1) != INTRODUCER)) {
			cursor_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			dyn_cursor_name_AST = currentAST.root;
		}
		else if ((tokenSet_8_.member(LA(1))) && (tokenSet_7_.member(LA(2)))) {
			extended_cursor_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			dyn_cursor_name_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = dyn_cursor_name_AST;
	}
	
	public void cursor_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST cursor_name_AST = null;
		
		id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		cursor_name_AST = currentAST.root;
		returnAST = cursor_name_AST;
	}
	
	public void set_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST set_clause_AST = null;
		
		column_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp49_AST = null;
		tmp49_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp49_AST);
		match(EQUALS_OP);
		update_source();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		set_clause_AST = currentAST.root;
		returnAST = set_clause_AST;
	}
	
	public string  column_name() //throws RecognitionException, TokenStreamException
{
		 string columnName = null ;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST column_name_AST = null;
		
		columnName=id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		column_name_AST = currentAST.root;
		returnAST = column_name_AST;
		return columnName;
	}
	
	public void update_source() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST update_source_AST = null;
		
		if ((tokenSet_9_.member(LA(1))))
		{
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			update_source_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_null)) {
			AST tmp50_AST = null;
			tmp50_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp50_AST);
			match(SQL2RW_null);
			update_source_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_default)) {
			AST tmp51_AST = null;
			tmp51_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp51_AST);
			match(SQL2RW_default);
			update_source_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = update_source_AST;
	}
	
	public IExpression  value_exp() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST value_exp_AST = null;
		
			IExpression expressionRhs = null;
		
		
		expression=term();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==MINUS_SIGN||LA(1)==CONCATENATION_OP||LA(1)==PLUS_SIGN) && (tokenSet_9_.member(LA(2))))
				{
					{
						if ((LA(1)==MINUS_SIGN||LA(1)==PLUS_SIGN))
						{
							term_op();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==CONCATENATION_OP)) {
							AST tmp52_AST = null;
							tmp52_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp52_AST);
							match(CONCATENATION_OP);
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					expressionRhs=term();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
									ITwoPartExpression twoPartExpression = new TwoPartExpression();
									twoPartExpression.Lhs = expression;
									twoPartExpression.Rhs = expressionRhs;
									expression = twoPartExpression;
								
					}
				}
				else
				{
					goto _loop360_breakloop;
				}
				
			}
_loop360_breakloop:			;
		}    // ( ... )*
		value_exp_AST = currentAST.root;
		returnAST = value_exp_AST;
		return expression;
	}
	
	public string  id() //throws RecognitionException, TokenStreamException
{
		 string strId = null ;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST id_AST = null;
		IToken  ident = null;
		AST ident_AST = null;
		IToken  ident2 = null;
		AST ident2_AST = null;
		
		{
			if ((LA(1)==INTRODUCER))
			{
				AST tmp53_AST = null;
				tmp53_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp53_AST);
				match(INTRODUCER);
				char_set_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==REGULAR_ID))
			{
				ident = LT(1);
				ident_AST = astFactory.create(ident);
				astFactory.addASTChild(ref currentAST, ident_AST);
				match(REGULAR_ID);
				if (0==inputState.guessing)
				{
					strId = ident.getText();
				}
			}
			else if ((LA(1)==DELIMITED_ID)) {
				ident2 = LT(1);
				ident2_AST = astFactory.create(ident2);
				astFactory.addASTChild(ref currentAST, ident2_AST);
				match(DELIMITED_ID);
				if (0==inputState.guessing)
				{
					strId = ident2.getText(); strId = strId.Trim(new char[] { '"', '[', ']', '\'', '`' });
				}
			}
			else if (((LA(1)==SQL2NRW_ada))&&(true)) {
				non_reserved_word();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		id_AST = currentAST.root;
		returnAST = id_AST;
		return strId;
	}
	
	public void char_set_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_set_name_AST = null;
		
		id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==PERIOD))
			{
				AST tmp54_AST = null;
				tmp54_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp54_AST);
				match(PERIOD);
				id();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==PERIOD))
					{
						AST tmp55_AST = null;
						tmp55_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp55_AST);
						match(PERIOD);
						id();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==CHAR_STRING||LA(1)==DELIMITED_ID||LA(1)==RIGHT_PAREN)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==CHAR_STRING||LA(1)==DELIMITED_ID||LA(1)==RIGHT_PAREN)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		char_set_name_AST = currentAST.root;
		returnAST = char_set_name_AST;
	}
	
	public void non_reserved_word() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST non_reserved_word_AST = null;
		
		AST tmp56_AST = null;
		tmp56_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp56_AST);
		match(SQL2NRW_ada);
		non_reserved_word_AST = currentAST.root;
		returnAST = non_reserved_word_AST;
	}
	
	public void schema_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST schema_name_AST = null;
		
		id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==PERIOD))
			{
				AST tmp57_AST = null;
				tmp57_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp57_AST);
				match(PERIOD);
				id();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==EOF)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		schema_name_AST = currentAST.root;
		returnAST = schema_name_AST;
	}
	
	public  string  qualified_name() //throws RecognitionException, TokenStreamException
{
		 string qualifiedName ;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST qualified_name_AST = null;
		
			qualifiedName = null;
			string ident;
		
		
		ident=id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			qualifiedName+=ident;
		}
		{
			if ((LA(1)==PERIOD) && (LA(2)==SQL2NRW_ada||LA(2)==REGULAR_ID||LA(2)==DELIMITED_ID||LA(2)==INTRODUCER))
			{
				AST tmp58_AST = null;
				tmp58_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp58_AST);
				match(PERIOD);
				ident=id();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					qualifiedName+="."; qualifiedName+=ident;
				}
				{
					if ((LA(1)==PERIOD) && (LA(2)==SQL2NRW_ada||LA(2)==REGULAR_ID||LA(2)==DELIMITED_ID||LA(2)==INTRODUCER))
					{
						AST tmp59_AST = null;
						tmp59_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp59_AST);
						match(PERIOD);
						ident=id();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							qualifiedName+="."; qualifiedName+=ident;
						}
					}
					else if ((tokenSet_10_.member(LA(1))) && (tokenSet_11_.member(LA(2)))) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else if ((tokenSet_10_.member(LA(1))) && (tokenSet_11_.member(LA(2)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		qualified_name_AST = currentAST.root;
		returnAST = qualified_name_AST;
		return qualifiedName ;
	}
	
	public SelectColumnCollection  select_list() //throws RecognitionException, TokenStreamException
{
		SelectColumnCollection selectColumnCollection;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST select_list_AST = null;
		
			selectColumnCollection = new SelectColumnCollection();
			SelectColumn selectColumn = null;
		
		
		if ((LA(1)==ASTERISK))
		{
			AST tmp60_AST = null;
			tmp60_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp60_AST);
			match(ASTERISK);
			if (0==inputState.guessing)
			{
				
						selectColumn = new SelectColumn();
						selectColumn.Name = "*";
						selectColumn.Alias = "*";
						selectColumnCollection.Add(selectColumn);
					
			}
			select_list_AST = currentAST.root;
		}
		else if ((tokenSet_12_.member(LA(1)))) {
			selectColumn=select_sublist();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				selectColumnCollection.Add(selectColumn);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp61_AST = null;
						tmp61_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp61_AST);
						match(COMMA);
						selectColumn=select_sublist();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							selectColumnCollection.Add(selectColumn);
						}
					}
					else
					{
						goto _loop159_breakloop;
					}
					
				}
_loop159_breakloop:				;
			}    // ( ... )*
			select_list_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = select_list_AST;
		return selectColumnCollection;
	}
	
	public SelectColumn  select_sublist() //throws RecognitionException, TokenStreamException
{
		SelectColumn selectColumn = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST select_sublist_AST = null;
		
			string tableName;
		
		
		bool synPredMatched162 = false;
		if (((LA(1)==SQL2NRW_ada||LA(1)==SQL2RW_module||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER) && (LA(2)==SQL2NRW_ada||LA(2)==PERIOD||LA(2)==REGULAR_ID||LA(2)==DELIMITED_ID||LA(2)==INTRODUCER)))
		{
			int _m162 = mark();
			synPredMatched162 = true;
			inputState.guessing++;
			try {
				{
					table_name();
					match(PERIOD);
					match(ASTERISK);
				}
			}
			catch (RecognitionException)
			{
				synPredMatched162 = false;
			}
			rewind(_m162);
			inputState.guessing--;
		}
		if ( synPredMatched162 )
		{
			tableName=table_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp62_AST = null;
			tmp62_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp62_AST);
			match(PERIOD);
			AST tmp63_AST = null;
			tmp63_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp63_AST);
			match(ASTERISK);
			if (0==inputState.guessing)
			{
				
							selectColumn = new SelectColumn();
							tableName = ".*";
							selectColumn.Name = tableName;
						
			}
			select_sublist_AST = currentAST.root;
		}
		else if ((tokenSet_9_.member(LA(1))) && (tokenSet_13_.member(LA(2)))) {
			selectColumn=derived_column();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			select_sublist_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = select_sublist_AST;
		return selectColumn;
	}
	
	public SelectColumn  derived_column() //throws RecognitionException, TokenStreamException
{
		SelectColumn selectColumn = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST derived_column_AST = null;
		
			selectColumn = new SelectColumn();
			IExpression expression = null;
			string columnName = null;
		
		
		expression=value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			selectColumn.Expression = expression;
		}
		{
			if ((LA(1)==SQL2RW_as))
			{
				AST tmp64_AST = null;
				tmp64_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp64_AST);
				match(SQL2RW_as);
				columnName=column_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					selectColumn.Alias = columnName;
				}
			}
			else if ((LA(1)==SQL2RW_from||LA(1)==SQL2RW_into||LA(1)==COMMA)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		derived_column_AST = currentAST.root;
		returnAST = derived_column_AST;
		return selectColumn;
	}
	
	public IExpression  value_exp_primary() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST value_exp_primary_AST = null;
		
			string tmp;
		
		
		if ((LA(1)==SQL2RW_avg||LA(1)==SQL2RW_count||LA(1)==SQL2RW_max||LA(1)==SQL2RW_min||LA(1)==SQL2RW_sum))
		{
			set_fct_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			value_exp_primary_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_case||LA(1)==SQL2RW_coalesce||LA(1)==SQL2RW_nullif)) {
			case_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			value_exp_primary_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_cast)) {
			cast_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			value_exp_primary_AST = currentAST.root;
		}
		else if (((tokenSet_14_.member(LA(1))) && (tokenSet_15_.member(LA(2))))&&(LA(1) == INTRODUCER)) {
			{
				bool synPredMatched168 = false;
				if (((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER) && (tokenSet_16_.member(LA(2)))))
				{
					int _m168 = mark();
					synPredMatched168 = true;
					inputState.guessing++;
					try {
						{
							column_ref();
						}
					}
					catch (RecognitionException)
					{
						synPredMatched168 = false;
					}
					rewind(_m168);
					inputState.guessing--;
				}
				if ( synPredMatched168 )
				{
					tmp=column_ref();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
										ITerminalExpression terminalExpression = new TerminalExpression();
										string column = "_" + tmp;
										terminalExpression.Value = column;
										expression = terminalExpression;
									
					}
				}
				else if ((tokenSet_17_.member(LA(1))) && (tokenSet_18_.member(LA(2)))) {
					tmp=unsigned_value_spec();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
										ITerminalExpression terminalExpression = new TerminalExpression();
										terminalExpression.Value = tmp;
										expression = terminalExpression;
									
					}
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			value_exp_primary_AST = currentAST.root;
		}
		else if (((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER) && (tokenSet_16_.member(LA(2))))&&(LA(1) != INTRODUCER)) {
			tmp=column_ref();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
								ITerminalExpression terminalExpression = new TerminalExpression();
								terminalExpression.Value = tmp;
								expression = terminalExpression;
						
			}
			value_exp_primary_AST = currentAST.root;
		}
		else if ((tokenSet_17_.member(LA(1))) && (tokenSet_18_.member(LA(2)))) {
			tmp=unsigned_value_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			if (0==inputState.guessing)
			{
				
								ITerminalExpression terminalExpression = new TerminalExpression();
								terminalExpression.Value = tmp;
								expression = terminalExpression;
						
			}
			value_exp_primary_AST = currentAST.root;
		}
		else {
			bool synPredMatched170 = false;
			if (((LA(1)==LEFT_PAREN) && (tokenSet_9_.member(LA(2)))))
			{
				int _m170 = mark();
				synPredMatched170 = true;
				inputState.guessing++;
				try {
					{
						match(LEFT_PAREN);
						value_exp();
						match(RIGHT_PAREN);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched170 = false;
				}
				rewind(_m170);
				inputState.guessing--;
			}
			if ( synPredMatched170 )
			{
				AST tmp65_AST = null;
				tmp65_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp65_AST);
				match(LEFT_PAREN);
				expression=value_exp();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp66_AST = null;
				tmp66_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp66_AST);
				match(RIGHT_PAREN);
				value_exp_primary_AST = currentAST.root;
			}
			else if ((LA(1)==LEFT_PAREN) && (tokenSet_3_.member(LA(2)))) {
				scalar_subquery();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				value_exp_primary_AST = currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			}
			returnAST = value_exp_primary_AST;
			return expression;
		}
		
	public void set_fct_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST set_fct_spec_AST = null;
		
		if ((LA(1)==SQL2RW_count))
		{
			AST tmp67_AST = null;
			tmp67_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp67_AST);
			match(SQL2RW_count);
			AST tmp68_AST = null;
			tmp68_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp68_AST);
			match(LEFT_PAREN);
			{
				if ((LA(1)==ASTERISK))
				{
					AST tmp69_AST = null;
					tmp69_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp69_AST);
					match(ASTERISK);
				}
				else if ((tokenSet_19_.member(LA(1)))) {
					{
						if ((LA(1)==SQL2RW_all||LA(1)==SQL2RW_distinct))
						{
							set_quantifier();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((tokenSet_9_.member(LA(1)))) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					value_exp();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			AST tmp70_AST = null;
			tmp70_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp70_AST);
			match(RIGHT_PAREN);
			set_fct_spec_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_avg||LA(1)==SQL2RW_max||LA(1)==SQL2RW_min||LA(1)==SQL2RW_sum)) {
			{
				switch ( LA(1) )
				{
				case SQL2RW_avg:
				{
					AST tmp71_AST = null;
					tmp71_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp71_AST);
					match(SQL2RW_avg);
					break;
				}
				case SQL2RW_max:
				{
					AST tmp72_AST = null;
					tmp72_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp72_AST);
					match(SQL2RW_max);
					break;
				}
				case SQL2RW_min:
				{
					AST tmp73_AST = null;
					tmp73_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp73_AST);
					match(SQL2RW_min);
					break;
				}
				case SQL2RW_sum:
				{
					AST tmp74_AST = null;
					tmp74_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp74_AST);
					match(SQL2RW_sum);
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			AST tmp75_AST = null;
			tmp75_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp75_AST);
			match(LEFT_PAREN);
			{
				if ((LA(1)==SQL2RW_all||LA(1)==SQL2RW_distinct))
				{
					set_quantifier();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((tokenSet_9_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp76_AST = null;
			tmp76_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp76_AST);
			match(RIGHT_PAREN);
			set_fct_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = set_fct_spec_AST;
	}
	
	public void case_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_exp_AST = null;
		
		if ((LA(1)==SQL2RW_coalesce||LA(1)==SQL2RW_nullif))
		{
			case_abbreviation();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			case_exp_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_case)) {
			case_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			case_exp_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = case_exp_AST;
	}
	
	public void cast_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST cast_spec_AST = null;
		
		AST tmp77_AST = null;
		tmp77_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp77_AST);
		match(SQL2RW_cast);
		AST tmp78_AST = null;
		tmp78_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp78_AST);
		match(LEFT_PAREN);
		cast_operand();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp79_AST = null;
		tmp79_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp79_AST);
		match(SQL2RW_as);
		cast_target();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp80_AST = null;
		tmp80_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp80_AST);
		match(RIGHT_PAREN);
		cast_spec_AST = currentAST.root;
		returnAST = cast_spec_AST;
	}
	
	public string  unsigned_value_spec() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unsigned_value_spec_AST = null;
		
		if ((tokenSet_20_.member(LA(1))))
		{
			literal=unsigned_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			unsigned_value_spec_AST = currentAST.root;
		}
		else if ((tokenSet_21_.member(LA(1)))) {
			literal=general_value_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			unsigned_value_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = unsigned_value_spec_AST;
		return literal;
	}
	
	public void scalar_subquery() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST scalar_subquery_AST = null;
		
		subquery();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		scalar_subquery_AST = currentAST.root;
		returnAST = scalar_subquery_AST;
	}
	
	public void set_quantifier() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST set_quantifier_AST = null;
		
		if ((LA(1)==SQL2RW_distinct))
		{
			AST tmp81_AST = null;
			tmp81_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp81_AST);
			match(SQL2RW_distinct);
			set_quantifier_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_all)) {
			AST tmp82_AST = null;
			tmp82_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp82_AST);
			match(SQL2RW_all);
			set_quantifier_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = set_quantifier_AST;
	}
	
	public void case_abbreviation() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_abbreviation_AST = null;
		
		if ((LA(1)==SQL2RW_nullif))
		{
			AST tmp83_AST = null;
			tmp83_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp83_AST);
			match(SQL2RW_nullif);
			AST tmp84_AST = null;
			tmp84_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp84_AST);
			match(LEFT_PAREN);
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp85_AST = null;
			tmp85_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp85_AST);
			match(COMMA);
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp86_AST = null;
			tmp86_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp86_AST);
			match(RIGHT_PAREN);
			case_abbreviation_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_coalesce)) {
			AST tmp87_AST = null;
			tmp87_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp87_AST);
			match(SQL2RW_coalesce);
			AST tmp88_AST = null;
			tmp88_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp88_AST);
			match(LEFT_PAREN);
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						AST tmp89_AST = null;
						tmp89_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp89_AST);
						match(COMMA);
						value_exp();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
					else
					{
						goto _loop180_breakloop;
					}
					
				}
_loop180_breakloop:				;
			}    // ( ... )*
			AST tmp90_AST = null;
			tmp90_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp90_AST);
			match(RIGHT_PAREN);
			case_abbreviation_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = case_abbreviation_AST;
	}
	
	public void case_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST case_spec_AST = null;
		
		if ((LA(1)==SQL2RW_case) && (tokenSet_9_.member(LA(2))))
		{
			simple_case();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			case_spec_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_case) && (LA(2)==SQL2RW_when)) {
			searched_case();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			case_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = case_spec_AST;
	}
	
	public void simple_case() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST simple_case_AST = null;
		
		AST tmp91_AST = null;
		tmp91_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp91_AST);
		match(SQL2RW_case);
		value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{ // ( ... )+
			int _cnt184=0;
			for (;;)
			{
				if ((LA(1)==SQL2RW_when))
				{
					simple_when_clause();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					if (_cnt184 >= 1) { goto _loop184_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
				}
				
				_cnt184++;
			}
_loop184_breakloop:			;
		}    // ( ... )+
		{
			if ((LA(1)==SQL2RW_else))
			{
				else_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==SQL2RW_end)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		AST tmp92_AST = null;
		tmp92_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp92_AST);
		match(SQL2RW_end);
		simple_case_AST = currentAST.root;
		returnAST = simple_case_AST;
	}
	
	public void searched_case() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST searched_case_AST = null;
		
		AST tmp93_AST = null;
		tmp93_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp93_AST);
		match(SQL2RW_case);
		{ // ( ... )+
			int _cnt191=0;
			for (;;)
			{
				if ((LA(1)==SQL2RW_when))
				{
					searched_when_clause();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					if (_cnt191 >= 1) { goto _loop191_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
				}
				
				_cnt191++;
			}
_loop191_breakloop:			;
		}    // ( ... )+
		{
			if ((LA(1)==SQL2RW_else))
			{
				else_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==SQL2RW_end)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		AST tmp94_AST = null;
		tmp94_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp94_AST);
		match(SQL2RW_end);
		searched_case_AST = currentAST.root;
		returnAST = searched_case_AST;
	}
	
	public void simple_when_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST simple_when_clause_AST = null;
		
		AST tmp95_AST = null;
		tmp95_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp95_AST);
		match(SQL2RW_when);
		value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp96_AST = null;
		tmp96_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp96_AST);
		match(SQL2RW_then);
		result();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		simple_when_clause_AST = currentAST.root;
		returnAST = simple_when_clause_AST;
	}
	
	public void else_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST else_clause_AST = null;
		
		AST tmp97_AST = null;
		tmp97_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp97_AST);
		match(SQL2RW_else);
		result();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		else_clause_AST = currentAST.root;
		returnAST = else_clause_AST;
	}
	
	public void result() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST result_AST = null;
		
		if ((tokenSet_9_.member(LA(1))))
		{
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			result_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_null)) {
			AST tmp98_AST = null;
			tmp98_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp98_AST);
			match(SQL2RW_null);
			result_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = result_AST;
	}
	
	public void searched_when_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST searched_when_clause_AST = null;
		
		AST tmp99_AST = null;
		tmp99_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp99_AST);
		match(SQL2RW_when);
		search_condition();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp100_AST = null;
		tmp100_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp100_AST);
		match(SQL2RW_then);
		result();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		searched_when_clause_AST = currentAST.root;
		returnAST = searched_when_clause_AST;
	}
	
	public IExpression  boolean_term() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_term_AST = null;
		
			IExpression expressionRhs = null;
		
		
		expression=boolean_factor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==SQL2RW_and))
				{
					boolean_factor_op();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					expressionRhs=boolean_factor();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
									ITwoPartExpression twoPartExpression = new TwoPartExpression();
									twoPartExpression.Lhs = expression;
									twoPartExpression.Rhs = expressionRhs;
									twoPartExpression.Operator = SqlOperator.BooleanFactorOperator;
									expression = twoPartExpression;
								
					}
				}
				else
				{
					goto _loop200_breakloop;
				}
				
			}
_loop200_breakloop:			;
		}    // ( ... )*
		boolean_term_AST = currentAST.root;
		returnAST = boolean_term_AST;
		return expression;
	}
	
	public void boolean_term_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_term_op_AST = null;
		
		AST tmp101_AST = null;
		tmp101_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp101_AST);
		match(SQL2RW_or);
		boolean_term_op_AST = currentAST.root;
		returnAST = boolean_term_op_AST;
	}
	
	public IExpression  boolean_factor() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_factor_AST = null;
		
		{
			if ((LA(1)==SQL2RW_not))
			{
				AST tmp102_AST = null;
				tmp102_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp102_AST);
				match(SQL2RW_not);
			}
			else if ((tokenSet_22_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		expression=boolean_test();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		boolean_factor_AST = currentAST.root;
		returnAST = boolean_factor_AST;
		return expression;
	}
	
	public void boolean_factor_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_factor_op_AST = null;
		
		AST tmp103_AST = null;
		tmp103_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp103_AST);
		match(SQL2RW_and);
		boolean_factor_op_AST = currentAST.root;
		returnAST = boolean_factor_op_AST;
	}
	
	public IExpression  boolean_test() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_test_AST = null;
		
		expression=boolean_primary();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_is))
			{
				AST tmp104_AST = null;
				tmp104_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp104_AST);
				match(SQL2RW_is);
				{
					if ((LA(1)==SQL2RW_not))
					{
						AST tmp105_AST = null;
						tmp105_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp105_AST);
						match(SQL2RW_not);
					}
					else if ((LA(1)==SQL2RW_false||LA(1)==SQL2RW_true||LA(1)==SQL2RW_unknown)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				truth_value();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_23_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		boolean_test_AST = currentAST.root;
		returnAST = boolean_test_AST;
		return expression;
	}
	
	public IExpression  boolean_primary() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST boolean_primary_AST = null;
		
		bool synPredMatched210 = false;
		if (((tokenSet_22_.member(LA(1))) && (tokenSet_24_.member(LA(2)))))
		{
			int _m210 = mark();
			synPredMatched210 = true;
			inputState.guessing++;
			try {
				{
					predicate();
				}
			}
			catch (RecognitionException)
			{
				synPredMatched210 = false;
			}
			rewind(_m210);
			inputState.guessing--;
		}
		if ( synPredMatched210 )
		{
			expression=predicate();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			boolean_primary_AST = currentAST.root;
		}
		else if ((LA(1)==LEFT_PAREN) && (tokenSet_1_.member(LA(2)))) {
			AST tmp106_AST = null;
			tmp106_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp106_AST);
			match(LEFT_PAREN);
			search_condition();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp107_AST = null;
			tmp107_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp107_AST);
			match(RIGHT_PAREN);
			boolean_primary_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = boolean_primary_AST;
		return expression;
	}
	
	public void truth_value() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST truth_value_AST = null;
		
		if ((LA(1)==SQL2RW_true))
		{
			AST tmp108_AST = null;
			tmp108_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp108_AST);
			match(SQL2RW_true);
			truth_value_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_false)) {
			AST tmp109_AST = null;
			tmp109_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp109_AST);
			match(SQL2RW_false);
			truth_value_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_unknown)) {
			AST tmp110_AST = null;
			tmp110_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp110_AST);
			match(SQL2RW_unknown);
			truth_value_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = truth_value_AST;
	}
	
	public IExpression  predicate() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST predicate_AST = null;
		
			ITwoPartExpression twoPartExpression = null;
			ILikeExpression likeExpression = null;
			INullExpression nullExpression = null;
			bool bNot = false;
		
		
		if ((tokenSet_25_.member(LA(1))))
		{
			expression=row_value_constructor();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				switch ( LA(1) )
				{
				case SQL2RW_between:
				case SQL2RW_in:
				case SQL2RW_like:
				case SQL2RW_not:
				{
					{
						if ((LA(1)==SQL2RW_not))
						{
							AST tmp111_AST = null;
							tmp111_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp111_AST);
							match(SQL2RW_not);
							if (0==inputState.guessing)
							{
								bNot = true;
							}
						}
						else if ((LA(1)==SQL2RW_between||LA(1)==SQL2RW_in||LA(1)==SQL2RW_like)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					{
						if ((LA(1)==SQL2RW_between))
						{
							between_predicate();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==SQL2RW_in)) {
							in_predicate();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==SQL2RW_like)) {
							likeExpression=like_predicate();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							if (0==inputState.guessing)
							{
								
															twoPartExpression = new TwoPartExpression();
															twoPartExpression.Lhs = expression;
															twoPartExpression.Rhs = likeExpression;
															twoPartExpression.Not = bNot;
															expression = twoPartExpression;
														
							}
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					break;
				}
				case SQL2RW_is:
				{
					nullExpression=null_predicate();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
										twoPartExpression = new TwoPartExpression();
										twoPartExpression.Lhs = expression;
										twoPartExpression.Rhs = nullExpression;
										expression = twoPartExpression;
									
					}
					break;
				}
				case SQL2RW_match:
				{
					match_predicate();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				case SQL2RW_overlaps:
				{
					overlaps_predicate();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					break;
				}
				default:
					if ((LA(1)==NOT_EQUALS_OP||LA(1)==LESS_THAN_OR_EQUALS_OP||LA(1)==GREATER_THAN_OR_EQUALS_OP||LA(1)==LESS_THAN_OP||LA(1)==EQUALS_OP||LA(1)==GREATER_THAN_OP) && (tokenSet_25_.member(LA(2))))
					{
						twoPartExpression=comp_predicate();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						if (0==inputState.guessing)
						{
							
											twoPartExpression.Lhs = expression;
											expression = twoPartExpression;
										
						}
					}
					else if ((LA(1)==NOT_EQUALS_OP||LA(1)==LESS_THAN_OR_EQUALS_OP||LA(1)==GREATER_THAN_OR_EQUALS_OP||LA(1)==LESS_THAN_OP||LA(1)==EQUALS_OP||LA(1)==GREATER_THAN_OP) && (LA(2)==SQL2RW_all||LA(2)==SQL2RW_any||LA(2)==SQL2RW_some)) {
						quantified_comp_predicate();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
					}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				break; }
			}
			predicate_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_exists)) {
			exists_predicate();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			predicate_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_unique)) {
			unique_predicate();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			predicate_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = predicate_AST;
		return expression;
	}
	
	public IExpression  row_value_constructor() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST row_value_constructor_AST = null;
		
		bool synPredMatched299 = false;
		if (((tokenSet_25_.member(LA(1))) && (tokenSet_26_.member(LA(2)))))
		{
			int _m299 = mark();
			synPredMatched299 = true;
			inputState.guessing++;
			try {
				{
					row_value_constructor_elem();
				}
			}
			catch (RecognitionException)
			{
				synPredMatched299 = false;
			}
			rewind(_m299);
			inputState.guessing--;
		}
		if ( synPredMatched299 )
		{
			expression=row_value_constructor_elem();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			row_value_constructor_AST = currentAST.root;
		}
		else if ((LA(1)==LEFT_PAREN) && (tokenSet_25_.member(LA(2)))) {
			AST tmp112_AST = null;
			tmp112_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp112_AST);
			match(LEFT_PAREN);
			row_value_const_list();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp113_AST = null;
			tmp113_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp113_AST);
			match(RIGHT_PAREN);
			row_value_constructor_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = row_value_constructor_AST;
		return expression;
	}
	
	public ITwoPartExpression  comp_predicate() //throws RecognitionException, TokenStreamException
{
		ITwoPartExpression twoPartExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST comp_predicate_AST = null;
		
			IExpression expressionRhs = null;
			SqlOperator op;
		
		
		op=comp_op();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		expressionRhs=row_value_constructor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			
					twoPartExpression = new TwoPartExpression();
					twoPartExpression.Rhs = expressionRhs;
					twoPartExpression.Operator = op;
				
		}
		comp_predicate_AST = currentAST.root;
		returnAST = comp_predicate_AST;
		return twoPartExpression;
	}
	
	public void between_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST between_predicate_AST = null;
		
		AST tmp114_AST = null;
		tmp114_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp114_AST);
		match(SQL2RW_between);
		row_value_constructor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp115_AST = null;
		tmp115_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp115_AST);
		match(SQL2RW_and);
		row_value_constructor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		between_predicate_AST = currentAST.root;
		returnAST = between_predicate_AST;
	}
	
	public void in_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST in_predicate_AST = null;
		
		AST tmp116_AST = null;
		tmp116_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp116_AST);
		match(SQL2RW_in);
		in_predicate_value();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		in_predicate_AST = currentAST.root;
		returnAST = in_predicate_AST;
	}
	
	public ILikeExpression  like_predicate() //throws RecognitionException, TokenStreamException
{
		ILikeExpression likeExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST like_predicate_AST = null;
		
			likeExpression = new LikeExpression();
			IExpression patternExpression, escapeExpression;
		
		
		AST tmp117_AST = null;
		tmp117_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp117_AST);
		match(SQL2RW_like);
		patternExpression=pattern();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			likeExpression.Pattern = patternExpression;
		}
		{
			if ((LA(1)==SQL2RW_escape))
			{
				AST tmp118_AST = null;
				tmp118_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp118_AST);
				match(SQL2RW_escape);
				escapeExpression=escape_char();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					likeExpression.Escape = escapeExpression;
				}
			}
			else if ((tokenSet_27_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		like_predicate_AST = currentAST.root;
		returnAST = like_predicate_AST;
		return likeExpression;
	}
	
	public INullExpression  null_predicate() //throws RecognitionException, TokenStreamException
{
		INullExpression nullExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST null_predicate_AST = null;
		
			nullExpression = new NullExpression();
		
		
		AST tmp119_AST = null;
		tmp119_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp119_AST);
		match(SQL2RW_is);
		{
			if ((LA(1)==SQL2RW_not))
			{
				AST tmp120_AST = null;
				tmp120_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp120_AST);
				match(SQL2RW_not);
				if (0==inputState.guessing)
				{
					nullExpression.Not = true;
				}
			}
			else if ((LA(1)==SQL2RW_null)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		AST tmp121_AST = null;
		tmp121_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp121_AST);
		match(SQL2RW_null);
		null_predicate_AST = currentAST.root;
		returnAST = null_predicate_AST;
		return nullExpression;
	}
	
	public void quantified_comp_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST quantified_comp_predicate_AST = null;
		
		comp_op();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_all))
			{
				AST tmp122_AST = null;
				tmp122_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp122_AST);
				match(SQL2RW_all);
			}
			else if ((LA(1)==SQL2RW_some)) {
				AST tmp123_AST = null;
				tmp123_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp123_AST);
				match(SQL2RW_some);
			}
			else if ((LA(1)==SQL2RW_any)) {
				AST tmp124_AST = null;
				tmp124_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp124_AST);
				match(SQL2RW_any);
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		table_subquery();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		quantified_comp_predicate_AST = currentAST.root;
		returnAST = quantified_comp_predicate_AST;
	}
	
	public void match_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST match_predicate_AST = null;
		
		AST tmp125_AST = null;
		tmp125_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp125_AST);
		match(SQL2RW_match);
		{
			if ((LA(1)==SQL2RW_unique))
			{
				AST tmp126_AST = null;
				tmp126_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp126_AST);
				match(SQL2RW_unique);
			}
			else if ((LA(1)==SQL2RW_full||LA(1)==SQL2RW_partial||LA(1)==LEFT_PAREN)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==SQL2RW_full))
			{
				AST tmp127_AST = null;
				tmp127_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp127_AST);
				match(SQL2RW_full);
			}
			else if ((LA(1)==SQL2RW_partial)) {
				AST tmp128_AST = null;
				tmp128_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp128_AST);
				match(SQL2RW_partial);
			}
			else if ((LA(1)==LEFT_PAREN)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		table_subquery();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		match_predicate_AST = currentAST.root;
		returnAST = match_predicate_AST;
	}
	
	public void overlaps_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST overlaps_predicate_AST = null;
		
		AST tmp129_AST = null;
		tmp129_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp129_AST);
		match(SQL2RW_overlaps);
		row_value_constructor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		overlaps_predicate_AST = currentAST.root;
		returnAST = overlaps_predicate_AST;
	}
	
	public void exists_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST exists_predicate_AST = null;
		
		AST tmp130_AST = null;
		tmp130_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp130_AST);
		match(SQL2RW_exists);
		table_subquery();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		exists_predicate_AST = currentAST.root;
		returnAST = exists_predicate_AST;
	}
	
	public void unique_predicate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unique_predicate_AST = null;
		
		AST tmp131_AST = null;
		tmp131_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp131_AST);
		match(SQL2RW_unique);
		table_subquery();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		unique_predicate_AST = currentAST.root;
		returnAST = unique_predicate_AST;
	}
	
	public SqlOperator  comp_op() //throws RecognitionException, TokenStreamException
{
		SqlOperator op;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST comp_op_AST = null;
		
			op = SqlOperator.Unknown;
		
		
		switch ( LA(1) )
		{
		case EQUALS_OP:
		{
			AST tmp132_AST = null;
			tmp132_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp132_AST);
			match(EQUALS_OP);
			if (0==inputState.guessing)
			{
				op = SqlOperator.Equals;
			}
			comp_op_AST = currentAST.root;
			break;
		}
		case NOT_EQUALS_OP:
		{
			AST tmp133_AST = null;
			tmp133_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp133_AST);
			match(NOT_EQUALS_OP);
			if (0==inputState.guessing)
			{
				op = SqlOperator.NotEquals;
			}
			comp_op_AST = currentAST.root;
			break;
		}
		case LESS_THAN_OP:
		{
			AST tmp134_AST = null;
			tmp134_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp134_AST);
			match(LESS_THAN_OP);
			if (0==inputState.guessing)
			{
				op = SqlOperator.LessThan;
			}
			comp_op_AST = currentAST.root;
			break;
		}
		case GREATER_THAN_OP:
		{
			AST tmp135_AST = null;
			tmp135_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp135_AST);
			match(GREATER_THAN_OP);
			if (0==inputState.guessing)
			{
				op = SqlOperator.GreaterThan;
			}
			comp_op_AST = currentAST.root;
			break;
		}
		case LESS_THAN_OR_EQUALS_OP:
		{
			AST tmp136_AST = null;
			tmp136_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp136_AST);
			match(LESS_THAN_OR_EQUALS_OP);
			if (0==inputState.guessing)
			{
				op = SqlOperator.LessThanOrEquals;
			}
			comp_op_AST = currentAST.root;
			break;
		}
		case GREATER_THAN_OR_EQUALS_OP:
		{
			AST tmp137_AST = null;
			tmp137_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp137_AST);
			match(GREATER_THAN_OR_EQUALS_OP);
			if (0==inputState.guessing)
			{
				op = SqlOperator.GreaterThanOrEquals;
			}
			comp_op_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = comp_op_AST;
		return op;
	}
	
	public void in_predicate_value() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST in_predicate_value_AST = null;
		
		bool synPredMatched221 = false;
		if (((LA(1)==LEFT_PAREN) && (tokenSet_3_.member(LA(2)))))
		{
			int _m221 = mark();
			synPredMatched221 = true;
			inputState.guessing++;
			try {
				{
					table_subquery();
				}
			}
			catch (RecognitionException)
			{
				synPredMatched221 = false;
			}
			rewind(_m221);
			inputState.guessing--;
		}
		if ( synPredMatched221 )
		{
			table_subquery();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			in_predicate_value_AST = currentAST.root;
		}
		else if ((LA(1)==LEFT_PAREN) && (tokenSet_9_.member(LA(2)))) {
			AST tmp138_AST = null;
			tmp138_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp138_AST);
			match(LEFT_PAREN);
			in_value_list();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp139_AST = null;
			tmp139_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp139_AST);
			match(RIGHT_PAREN);
			in_predicate_value_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = in_predicate_value_AST;
	}
	
	public void table_subquery() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_subquery_AST = null;
		
		subquery();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		table_subquery_AST = currentAST.root;
		returnAST = table_subquery_AST;
	}
	
	public void in_value_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST in_value_list_AST = null;
		
		value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp140_AST = null;
					tmp140_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp140_AST);
					match(COMMA);
					value_exp();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop224_breakloop;
				}
				
			}
_loop224_breakloop:			;
		}    // ( ... )*
		in_value_list_AST = currentAST.root;
		returnAST = in_value_list_AST;
	}
	
	public IExpression  pattern() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST pattern_AST = null;
		
		expression=char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		pattern_AST = currentAST.root;
		returnAST = pattern_AST;
		return expression;
	}
	
	public IExpression  escape_char() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST escape_char_AST = null;
		
		expression=char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		escape_char_AST = currentAST.root;
		returnAST = escape_char_AST;
		return expression;
	}
	
	public IExpression  char_value_exp() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_value_exp_AST = null;
		
		expression=value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		char_value_exp_AST = currentAST.root;
		returnAST = char_value_exp_AST;
		return expression;
	}
	
	public void cast_operand() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST cast_operand_AST = null;
		
		if ((tokenSet_9_.member(LA(1))))
		{
			value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			cast_operand_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_null)) {
			AST tmp141_AST = null;
			tmp141_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp141_AST);
			match(SQL2RW_null);
			cast_operand_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = cast_operand_AST;
	}
	
	public void cast_target() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST cast_target_AST = null;
		
		if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
		{
			domain_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			cast_target_AST = currentAST.root;
		}
		else if ((tokenSet_28_.member(LA(1)))) {
			data_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			cast_target_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = cast_target_AST;
	}
	
	public void domain_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST domain_name_AST = null;
		
		qualified_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		domain_name_AST = currentAST.root;
		returnAST = domain_name_AST;
	}
	
	public void data_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST data_type_AST = null;
		
		switch ( LA(1) )
		{
		case SQL2RW_char:
		case SQL2RW_character:
		case SQL2RW_varchar:
		{
			char_string_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				if ((LA(1)==SQL2RW_character))
				{
					AST tmp142_AST = null;
					tmp142_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp142_AST);
					match(SQL2RW_character);
					AST tmp143_AST = null;
					tmp143_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp143_AST);
					match(SQL2RW_set);
					char_set_name();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			data_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_national:
		case SQL2RW_nchar:
		{
			national_char_string_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			data_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_bit:
		{
			bit_string_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			data_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_dec:
		case SQL2RW_decimal:
		case SQL2RW_double:
		case SQL2RW_float:
		case SQL2RW_int:
		case SQL2RW_integer:
		case SQL2RW_numeric:
		case SQL2RW_real:
		case SQL2RW_smallint:
		{
			num_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			data_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_date:
		case SQL2RW_time:
		case SQL2RW_timestamp:
		{
			datetime_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			data_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_interval:
		{
			interval_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			data_type_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = data_type_AST;
	}
	
	public void char_string_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_string_type_AST = null;
		
		if ((LA(1)==SQL2RW_character) && (LA(2)==SQL2RW_character||LA(2)==LEFT_PAREN||LA(2)==RIGHT_PAREN))
		{
			AST tmp144_AST = null;
			tmp144_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp144_AST);
			match(SQL2RW_character);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp145_AST = null;
					tmp145_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp145_AST);
					match(LEFT_PAREN);
					length();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp146_AST = null;
					tmp146_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp146_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==SQL2RW_character||LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			char_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_char) && (LA(2)==SQL2RW_character||LA(2)==LEFT_PAREN||LA(2)==RIGHT_PAREN)) {
			AST tmp147_AST = null;
			tmp147_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp147_AST);
			match(SQL2RW_char);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp148_AST = null;
					tmp148_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp148_AST);
					match(LEFT_PAREN);
					length();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp149_AST = null;
					tmp149_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp149_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==SQL2RW_character||LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			char_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_character) && (LA(2)==SQL2RW_varying)) {
			AST tmp150_AST = null;
			tmp150_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp150_AST);
			match(SQL2RW_character);
			AST tmp151_AST = null;
			tmp151_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp151_AST);
			match(SQL2RW_varying);
			AST tmp152_AST = null;
			tmp152_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp152_AST);
			match(LEFT_PAREN);
			length();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp153_AST = null;
			tmp153_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp153_AST);
			match(RIGHT_PAREN);
			char_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_char) && (LA(2)==SQL2RW_varying)) {
			AST tmp154_AST = null;
			tmp154_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp154_AST);
			match(SQL2RW_char);
			AST tmp155_AST = null;
			tmp155_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp155_AST);
			match(SQL2RW_varying);
			AST tmp156_AST = null;
			tmp156_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp156_AST);
			match(LEFT_PAREN);
			length();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp157_AST = null;
			tmp157_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp157_AST);
			match(RIGHT_PAREN);
			char_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_varchar)) {
			AST tmp158_AST = null;
			tmp158_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp158_AST);
			match(SQL2RW_varchar);
			AST tmp159_AST = null;
			tmp159_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp159_AST);
			match(LEFT_PAREN);
			length();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp160_AST = null;
			tmp160_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp160_AST);
			match(RIGHT_PAREN);
			char_string_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = char_string_type_AST;
	}
	
	public void national_char_string_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST national_char_string_type_AST = null;
		
		if ((LA(1)==SQL2RW_national))
		{
			AST tmp161_AST = null;
			tmp161_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp161_AST);
			match(SQL2RW_national);
			{
				if ((LA(1)==SQL2RW_character) && (LA(2)==LEFT_PAREN||LA(2)==RIGHT_PAREN))
				{
					AST tmp162_AST = null;
					tmp162_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp162_AST);
					match(SQL2RW_character);
					{
						if ((LA(1)==LEFT_PAREN))
						{
							AST tmp163_AST = null;
							tmp163_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp163_AST);
							match(LEFT_PAREN);
							length();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							AST tmp164_AST = null;
							tmp164_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp164_AST);
							match(RIGHT_PAREN);
						}
						else if ((LA(1)==RIGHT_PAREN)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
				}
				else if ((LA(1)==SQL2RW_char) && (LA(2)==LEFT_PAREN||LA(2)==RIGHT_PAREN)) {
					AST tmp165_AST = null;
					tmp165_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp165_AST);
					match(SQL2RW_char);
					{
						if ((LA(1)==LEFT_PAREN))
						{
							AST tmp166_AST = null;
							tmp166_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp166_AST);
							match(LEFT_PAREN);
							length();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							AST tmp167_AST = null;
							tmp167_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp167_AST);
							match(RIGHT_PAREN);
						}
						else if ((LA(1)==RIGHT_PAREN)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
				}
				else if ((LA(1)==SQL2RW_character) && (LA(2)==SQL2RW_varying)) {
					AST tmp168_AST = null;
					tmp168_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp168_AST);
					match(SQL2RW_character);
					AST tmp169_AST = null;
					tmp169_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp169_AST);
					match(SQL2RW_varying);
					AST tmp170_AST = null;
					tmp170_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp170_AST);
					match(LEFT_PAREN);
					length();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp171_AST = null;
					tmp171_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp171_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==SQL2RW_char) && (LA(2)==SQL2RW_varying)) {
					AST tmp172_AST = null;
					tmp172_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp172_AST);
					match(SQL2RW_char);
					AST tmp173_AST = null;
					tmp173_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp173_AST);
					match(SQL2RW_varying);
					AST tmp174_AST = null;
					tmp174_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp174_AST);
					match(LEFT_PAREN);
					length();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp175_AST = null;
					tmp175_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp175_AST);
					match(RIGHT_PAREN);
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			national_char_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_nchar) && (LA(2)==LEFT_PAREN||LA(2)==RIGHT_PAREN)) {
			AST tmp176_AST = null;
			tmp176_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp176_AST);
			match(SQL2RW_nchar);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp177_AST = null;
					tmp177_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp177_AST);
					match(LEFT_PAREN);
					length();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp178_AST = null;
					tmp178_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp178_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			national_char_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_nchar) && (LA(2)==SQL2RW_varying)) {
			AST tmp179_AST = null;
			tmp179_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp179_AST);
			match(SQL2RW_nchar);
			AST tmp180_AST = null;
			tmp180_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp180_AST);
			match(SQL2RW_varying);
			AST tmp181_AST = null;
			tmp181_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp181_AST);
			match(LEFT_PAREN);
			length();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp182_AST = null;
			tmp182_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp182_AST);
			match(RIGHT_PAREN);
			national_char_string_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = national_char_string_type_AST;
	}
	
	public void bit_string_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bit_string_type_AST = null;
		
		if ((LA(1)==SQL2RW_bit) && (LA(2)==LEFT_PAREN||LA(2)==RIGHT_PAREN))
		{
			AST tmp183_AST = null;
			tmp183_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp183_AST);
			match(SQL2RW_bit);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp184_AST = null;
					tmp184_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp184_AST);
					match(LEFT_PAREN);
					length();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp185_AST = null;
					tmp185_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp185_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			bit_string_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_bit) && (LA(2)==SQL2RW_varying)) {
			AST tmp186_AST = null;
			tmp186_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp186_AST);
			match(SQL2RW_bit);
			AST tmp187_AST = null;
			tmp187_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp187_AST);
			match(SQL2RW_varying);
			AST tmp188_AST = null;
			tmp188_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp188_AST);
			match(LEFT_PAREN);
			length();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp189_AST = null;
			tmp189_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp189_AST);
			match(RIGHT_PAREN);
			bit_string_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = bit_string_type_AST;
	}
	
	public void num_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST num_type_AST = null;
		
		if ((LA(1)==SQL2RW_dec||LA(1)==SQL2RW_decimal||LA(1)==SQL2RW_int||LA(1)==SQL2RW_integer||LA(1)==SQL2RW_numeric||LA(1)==SQL2RW_smallint))
		{
			exact_num_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			num_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_double||LA(1)==SQL2RW_float||LA(1)==SQL2RW_real)) {
			approximate_num_type();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			num_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = num_type_AST;
	}
	
	public void datetime_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST datetime_type_AST = null;
		
		if ((LA(1)==SQL2RW_date))
		{
			AST tmp190_AST = null;
			tmp190_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp190_AST);
			match(SQL2RW_date);
			datetime_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_time)) {
			AST tmp191_AST = null;
			tmp191_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp191_AST);
			match(SQL2RW_time);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp192_AST = null;
					tmp192_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp192_AST);
					match(LEFT_PAREN);
					time_precision();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp193_AST = null;
					tmp193_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp193_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==SQL2RW_with||LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			{
				if ((LA(1)==SQL2RW_with))
				{
					AST tmp194_AST = null;
					tmp194_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp194_AST);
					match(SQL2RW_with);
					AST tmp195_AST = null;
					tmp195_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp195_AST);
					match(SQL2RW_time);
					AST tmp196_AST = null;
					tmp196_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp196_AST);
					match(SQL2RW_zone);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			datetime_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_timestamp)) {
			AST tmp197_AST = null;
			tmp197_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp197_AST);
			match(SQL2RW_timestamp);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp198_AST = null;
					tmp198_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp198_AST);
					match(LEFT_PAREN);
					timestamp_precision();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp199_AST = null;
					tmp199_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp199_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==SQL2RW_with||LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			{
				if ((LA(1)==SQL2RW_with))
				{
					AST tmp200_AST = null;
					tmp200_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp200_AST);
					match(SQL2RW_with);
					AST tmp201_AST = null;
					tmp201_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp201_AST);
					match(SQL2RW_time);
					AST tmp202_AST = null;
					tmp202_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp202_AST);
					match(SQL2RW_zone);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			datetime_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = datetime_type_AST;
	}
	
	public void interval_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interval_type_AST = null;
		
		AST tmp203_AST = null;
		tmp203_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp203_AST);
		match(SQL2RW_interval);
		interval_qualifier();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		interval_type_AST = currentAST.root;
		returnAST = interval_type_AST;
	}
	
	public void length() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST length_AST = null;
		
		AST tmp204_AST = null;
		tmp204_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp204_AST);
		match(UNSIGNED_INTEGER);
		length_AST = currentAST.root;
		returnAST = length_AST;
	}
	
	public void precision() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST precision_AST = null;
		
		AST tmp205_AST = null;
		tmp205_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp205_AST);
		match(UNSIGNED_INTEGER);
		precision_AST = currentAST.root;
		returnAST = precision_AST;
	}
	
	public void scale() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST scale_AST = null;
		
		AST tmp206_AST = null;
		tmp206_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp206_AST);
		match(UNSIGNED_INTEGER);
		scale_AST = currentAST.root;
		returnAST = scale_AST;
	}
	
	public void exact_num_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST exact_num_type_AST = null;
		
		switch ( LA(1) )
		{
		case SQL2RW_numeric:
		{
			AST tmp207_AST = null;
			tmp207_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp207_AST);
			match(SQL2RW_numeric);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp208_AST = null;
					tmp208_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp208_AST);
					match(LEFT_PAREN);
					precision();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{
						if ((LA(1)==COMMA))
						{
							AST tmp209_AST = null;
							tmp209_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp209_AST);
							match(COMMA);
							scale();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==RIGHT_PAREN)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					AST tmp210_AST = null;
					tmp210_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp210_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			exact_num_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_decimal:
		{
			AST tmp211_AST = null;
			tmp211_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp211_AST);
			match(SQL2RW_decimal);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp212_AST = null;
					tmp212_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp212_AST);
					match(LEFT_PAREN);
					precision();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{
						if ((LA(1)==COMMA))
						{
							AST tmp213_AST = null;
							tmp213_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp213_AST);
							match(COMMA);
							scale();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==RIGHT_PAREN)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					AST tmp214_AST = null;
					tmp214_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp214_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			exact_num_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_dec:
		{
			AST tmp215_AST = null;
			tmp215_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp215_AST);
			match(SQL2RW_dec);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp216_AST = null;
					tmp216_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp216_AST);
					match(LEFT_PAREN);
					precision();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{
						if ((LA(1)==COMMA))
						{
							AST tmp217_AST = null;
							tmp217_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp217_AST);
							match(COMMA);
							scale();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else if ((LA(1)==RIGHT_PAREN)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					AST tmp218_AST = null;
					tmp218_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp218_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			exact_num_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_integer:
		{
			AST tmp219_AST = null;
			tmp219_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp219_AST);
			match(SQL2RW_integer);
			exact_num_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_int:
		{
			AST tmp220_AST = null;
			tmp220_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp220_AST);
			match(SQL2RW_int);
			exact_num_type_AST = currentAST.root;
			break;
		}
		case SQL2RW_smallint:
		{
			AST tmp221_AST = null;
			tmp221_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp221_AST);
			match(SQL2RW_smallint);
			exact_num_type_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = exact_num_type_AST;
	}
	
	public void approximate_num_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST approximate_num_type_AST = null;
		
		if ((LA(1)==SQL2RW_float))
		{
			AST tmp222_AST = null;
			tmp222_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp222_AST);
			match(SQL2RW_float);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp223_AST = null;
					tmp223_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp223_AST);
					match(LEFT_PAREN);
					precision();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					AST tmp224_AST = null;
					tmp224_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp224_AST);
					match(RIGHT_PAREN);
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			approximate_num_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_real)) {
			AST tmp225_AST = null;
			tmp225_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp225_AST);
			match(SQL2RW_real);
			approximate_num_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_double)) {
			AST tmp226_AST = null;
			tmp226_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp226_AST);
			match(SQL2RW_double);
			AST tmp227_AST = null;
			tmp227_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp227_AST);
			match(SQL2RW_precision);
			approximate_num_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = approximate_num_type_AST;
	}
	
	public void time_precision() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST time_precision_AST = null;
		
		AST tmp228_AST = null;
		tmp228_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp228_AST);
		match(UNSIGNED_INTEGER);
		time_precision_AST = currentAST.root;
		returnAST = time_precision_AST;
	}
	
	public void timestamp_precision() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST timestamp_precision_AST = null;
		
		AST tmp229_AST = null;
		tmp229_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp229_AST);
		match(UNSIGNED_INTEGER);
		timestamp_precision_AST = currentAST.root;
		returnAST = timestamp_precision_AST;
	}
	
	public void interval_qualifier() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interval_qualifier_AST = null;
		
		if ((LA(1)==SQL2RW_day||LA(1)==SQL2RW_hour||LA(1)==SQL2RW_minute||LA(1)==SQL2RW_month||LA(1)==SQL2RW_year))
		{
			start_field();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				if ((LA(1)==SQL2RW_to))
				{
					AST tmp230_AST = null;
					tmp230_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp230_AST);
					match(SQL2RW_to);
					end_field();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((tokenSet_29_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			interval_qualifier_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_second)) {
			AST tmp231_AST = null;
			tmp231_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp231_AST);
			match(SQL2RW_second);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp232_AST = null;
					tmp232_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp232_AST);
					match(LEFT_PAREN);
					AST tmp233_AST = null;
					tmp233_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp233_AST);
					match(UNSIGNED_INTEGER);
					{
						if ((LA(1)==COMMA))
						{
							AST tmp234_AST = null;
							tmp234_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp234_AST);
							match(COMMA);
							AST tmp235_AST = null;
							tmp235_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp235_AST);
							match(UNSIGNED_INTEGER);
						}
						else if ((LA(1)==RIGHT_PAREN)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					AST tmp236_AST = null;
					tmp236_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp236_AST);
					match(RIGHT_PAREN);
				}
				else if ((tokenSet_29_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			interval_qualifier_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = interval_qualifier_AST;
	}
	
	public void subquery() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST subquery_AST = null;
		
		AST tmp237_AST = null;
		tmp237_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp237_AST);
		match(LEFT_PAREN);
		query_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp238_AST = null;
		tmp238_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp238_AST);
		match(RIGHT_PAREN);
		subquery_AST = currentAST.root;
		returnAST = subquery_AST;
	}
	
	public IQueryExpression  query_term() //throws RecognitionException, TokenStreamException
{
		IQueryExpression queryExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST query_term_AST = null;
		
			IQueryExpression queryExpression2;
			CombineOperation op = CombineOperation.Union;
			bool all = false; bool corresponding = false;
		
		
		queryExpression=query_primary();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==SQL2RW_intersect))
				{
					AST tmp239_AST = null;
					tmp239_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp239_AST);
					match(SQL2RW_intersect);
					if (0==inputState.guessing)
					{
						op = CombineOperation.Intersect;
					}
					{
						if ((LA(1)==SQL2RW_all))
						{
							AST tmp240_AST = null;
							tmp240_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp240_AST);
							match(SQL2RW_all);
							if (0==inputState.guessing)
							{
								all = true;
							}
						}
						else if ((tokenSet_2_.member(LA(1)))) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					{
						if ((LA(1)==SQL2RW_corresponding))
						{
							corresponding_spec();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
							if (0==inputState.guessing)
							{
								corresponding = true;
							}
						}
						else if ((tokenSet_3_.member(LA(1)))) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
					queryExpression2=query_primary();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
										IQueryExpression queryExpression1 = queryExpression;
										ISetCombinationExpression setCombinationExpression = new SetCombinationExpression();				
										setCombinationExpression.Operator = op;
										setCombinationExpression.All = all;
										setCombinationExpression.Corresponding = corresponding;
										setCombinationExpression.Expression1 = queryExpression1;
										setCombinationExpression.Expression2 = queryExpression2;
										queryExpression = setCombinationExpression;
									
					}
				}
				else
				{
					goto _loop285_breakloop;
				}
				
			}
_loop285_breakloop:			;
		}    // ( ... )*
		query_term_AST = currentAST.root;
		returnAST = query_term_AST;
		return queryExpression;
	}
	
	public void corresponding_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST corresponding_spec_AST = null;
		
		AST tmp241_AST = null;
		tmp241_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp241_AST);
		match(SQL2RW_corresponding);
		{
			if ((LA(1)==SQL2RW_by))
			{
				AST tmp242_AST = null;
				tmp242_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp242_AST);
				match(SQL2RW_by);
				AST tmp243_AST = null;
				tmp243_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp243_AST);
				match(LEFT_PAREN);
				column_name_list();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp244_AST = null;
				tmp244_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp244_AST);
				match(RIGHT_PAREN);
			}
			else if ((tokenSet_3_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		corresponding_spec_AST = currentAST.root;
		returnAST = corresponding_spec_AST;
	}
	
	public IQueryExpression  query_primary() //throws RecognitionException, TokenStreamException
{
		IQueryExpression queryExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST query_primary_AST = null;
		
		if ((LA(1)==SQL2RW_select||LA(1)==SQL2RW_table||LA(1)==SQL2RW_values))
		{
			queryExpression=simple_table();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			query_primary_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2NRW_ada||LA(1)==SQL2RW_module||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==LEFT_PAREN||LA(1)==INTRODUCER)) {
			table_ref();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			query_primary_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = query_primary_AST;
		return queryExpression;
	}
	
	public IQueryExpression  simple_table() //throws RecognitionException, TokenStreamException
{
		IQueryExpression queryExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST simple_table_AST = null;
		
		if ((LA(1)==SQL2RW_select))
		{
			queryExpression=query_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			simple_table_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_values)) {
			table_value_constructor();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			simple_table_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_table)) {
			explicit_table();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			simple_table_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = simple_table_AST;
		return queryExpression;
	}
	
	public IQueryExpression  table_ref() //throws RecognitionException, TokenStreamException
{
		IQueryExpression queryExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_ref_AST = null;
		
		queryExpression=table_ref_aux();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==SQL2RW_full||LA(1)==SQL2RW_inner||LA(1)==SQL2RW_join||LA(1)==SQL2RW_left||LA(1)==SQL2RW_natural||LA(1)==SQL2RW_right||LA(1)==SQL2RW_union) && (tokenSet_30_.member(LA(2))))
				{
					qualified_join();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((LA(1)==SQL2RW_cross) && (LA(2)==SQL2RW_join)) {
					cross_join();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop309_breakloop;
				}
				
			}
_loop309_breakloop:			;
		}    // ( ... )*
		table_ref_AST = currentAST.root;
		returnAST = table_ref_AST;
		return queryExpression;
	}
	
	public ISelectExpression  query_spec() //throws RecognitionException, TokenStreamException
{
		ISelectExpression selectExpression;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST query_spec_AST = null;
		
			selectExpression = new SelectExpression();
			ITableExpression tableExpression;
			SelectColumnCollection selectList;
		
		
		AST tmp245_AST = null;
		tmp245_AST = astFactory.create(LT(1));
		astFactory.makeASTRoot(ref currentAST, tmp245_AST);
		match(SQL2RW_select);
		{
			if ((LA(1)==SQL2RW_all||LA(1)==SQL2RW_distinct))
			{
				set_quantifier();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_31_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		selectList=select_list();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			selectExpression.SelectList = selectList;
		}
		{
			if ((LA(1)==SQL2RW_into))
			{
				into_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==SQL2RW_from)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		tableExpression=table_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			selectExpression.TableExpression = tableExpression;
		}
		query_spec_AST = currentAST.root;
		returnAST = query_spec_AST;
		return selectExpression;
	}
	
	public void table_value_constructor() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_value_constructor_AST = null;
		
		AST tmp246_AST = null;
		tmp246_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp246_AST);
		match(SQL2RW_values);
		table_value_const_list();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		table_value_constructor_AST = currentAST.root;
		returnAST = table_value_constructor_AST;
	}
	
	public void explicit_table() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST explicit_table_AST = null;
		
		AST tmp247_AST = null;
		tmp247_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp247_AST);
		match(SQL2RW_table);
		table_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		explicit_table_AST = currentAST.root;
		returnAST = explicit_table_AST;
	}
	
	public ITableExpression  table_exp() //throws RecognitionException, TokenStreamException
{
		ITableExpression tableExpression;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_exp_AST = null;
		
			tableExpression = new TableExpression();
			QueryExpressionCollection from;
			IExpression where;
		
		
		from=from_clause();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			tableExpression.From = from;
		}
		{
			if ((LA(1)==SQL2RW_where))
			{
				where=where_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					tableExpression.Where = where;
				}
			}
			else if ((tokenSet_32_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==SQL2RW_group))
			{
				group_by_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_33_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==SQL2RW_having))
			{
				having_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_34_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		table_exp_AST = currentAST.root;
		returnAST = table_exp_AST;
		return tableExpression;
	}
	
	public void table_value_const_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_value_const_list_AST = null;
		
		row_value_constructor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp248_AST = null;
					tmp248_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp248_AST);
					match(COMMA);
					row_value_constructor();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop296_breakloop;
				}
				
			}
_loop296_breakloop:			;
		}    // ( ... )*
		table_value_const_list_AST = currentAST.root;
		returnAST = table_value_const_list_AST;
	}
	
	public IExpression  row_value_constructor_elem() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST row_value_constructor_elem_AST = null;
		
		if ((tokenSet_9_.member(LA(1))))
		{
			expression=value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			row_value_constructor_elem_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_null)) {
			AST tmp249_AST = null;
			tmp249_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp249_AST);
			match(SQL2RW_null);
			if (0==inputState.guessing)
			{
				
							ITerminalExpression terminalExpression = new TerminalExpression();
							terminalExpression.Value = "null";
							expression = terminalExpression;
						
			}
			row_value_constructor_elem_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_default)) {
			AST tmp250_AST = null;
			tmp250_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp250_AST);
			match(SQL2RW_default);
			row_value_constructor_elem_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = row_value_constructor_elem_AST;
		return expression;
	}
	
	public void row_value_const_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST row_value_const_list_AST = null;
		
		row_value_constructor_elem();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp251_AST = null;
					tmp251_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp251_AST);
					match(COMMA);
					row_value_constructor_elem();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop303_breakloop;
				}
				
			}
_loop303_breakloop:			;
		}    // ( ... )*
		row_value_const_list_AST = currentAST.root;
		returnAST = row_value_const_list_AST;
	}
	
	public void joined_table() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST joined_table_AST = null;
		
		table_ref_aux();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_full||LA(1)==SQL2RW_inner||LA(1)==SQL2RW_join||LA(1)==SQL2RW_left||LA(1)==SQL2RW_natural||LA(1)==SQL2RW_right||LA(1)==SQL2RW_union))
			{
				qualified_join();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==SQL2RW_cross)) {
				cross_join();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		joined_table_AST = currentAST.root;
		returnAST = joined_table_AST;
	}
	
	public IQueryExpression  table_ref_aux() //throws RecognitionException, TokenStreamException
{
		IQueryExpression queryExpression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_ref_aux_AST = null;
		
			string tableName;
		
		
		{
			if ((LA(1)==SQL2NRW_ada||LA(1)==SQL2RW_module||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
			{
				tableName=table_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					
								IJoinTableSelect joinTableSelect = new JoinTableSelect();
								joinTableSelect.TableName = tableName;
								queryExpression = joinTableSelect;
							
				}
			}
			else if ((LA(1)==LEFT_PAREN)) {
				table_subquery();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		{
			if ((LA(1)==SQL2NRW_ada||LA(1)==SQL2RW_as||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
			{
				{
					if ((LA(1)==SQL2RW_as))
					{
						AST tmp252_AST = null;
						tmp252_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp252_AST);
						match(SQL2RW_as);
					}
					else if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				correlation_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{
					if ((LA(1)==LEFT_PAREN))
					{
						AST tmp253_AST = null;
						tmp253_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp253_AST);
						match(LEFT_PAREN);
						derived_column_list();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, returnAST);
						}
						AST tmp254_AST = null;
						tmp254_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp254_AST);
						match(RIGHT_PAREN);
					}
					else if ((tokenSet_35_.member(LA(1)))) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
			}
			else if ((tokenSet_35_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		table_ref_aux_AST = currentAST.root;
		returnAST = table_ref_aux_AST;
		return queryExpression;
	}
	
	public void qualified_join() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST qualified_join_AST = null;
		
		if ((LA(1)==SQL2RW_full||LA(1)==SQL2RW_inner||LA(1)==SQL2RW_join||LA(1)==SQL2RW_left||LA(1)==SQL2RW_right))
		{
			{
				if ((LA(1)==SQL2RW_inner))
				{
					AST tmp255_AST = null;
					tmp255_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp255_AST);
					match(SQL2RW_inner);
				}
				else if ((LA(1)==SQL2RW_full||LA(1)==SQL2RW_left||LA(1)==SQL2RW_right)) {
					outer_join_type();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{
						if ((LA(1)==SQL2RW_outer))
						{
							AST tmp256_AST = null;
							tmp256_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp256_AST);
							match(SQL2RW_outer);
						}
						else if ((LA(1)==SQL2RW_join)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
				}
				else if ((LA(1)==SQL2RW_join)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			AST tmp257_AST = null;
			tmp257_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp257_AST);
			match(SQL2RW_join);
			table_ref();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			join_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			qualified_join_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_natural)) {
			AST tmp258_AST = null;
			tmp258_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp258_AST);
			match(SQL2RW_natural);
			{
				if ((LA(1)==SQL2RW_inner))
				{
					AST tmp259_AST = null;
					tmp259_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp259_AST);
					match(SQL2RW_inner);
				}
				else if ((LA(1)==SQL2RW_full||LA(1)==SQL2RW_left||LA(1)==SQL2RW_right)) {
					outer_join_type();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					{
						if ((LA(1)==SQL2RW_outer))
						{
							AST tmp260_AST = null;
							tmp260_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp260_AST);
							match(SQL2RW_outer);
						}
						else if ((LA(1)==SQL2RW_join)) {
						}
						else
						{
							throw new NoViableAltException(LT(1), getFilename());
						}
						
					}
				}
				else if ((LA(1)==SQL2RW_join)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			AST tmp261_AST = null;
			tmp261_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp261_AST);
			match(SQL2RW_join);
			table_ref();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			qualified_join_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_union)) {
			AST tmp262_AST = null;
			tmp262_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp262_AST);
			match(SQL2RW_union);
			AST tmp263_AST = null;
			tmp263_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp263_AST);
			match(SQL2RW_join);
			table_ref();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			qualified_join_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = qualified_join_AST;
	}
	
	public void cross_join() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST cross_join_AST = null;
		
		AST tmp264_AST = null;
		tmp264_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp264_AST);
		match(SQL2RW_cross);
		AST tmp265_AST = null;
		tmp265_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp265_AST);
		match(SQL2RW_join);
		table_ref();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		cross_join_AST = currentAST.root;
		returnAST = cross_join_AST;
	}
	
	public void correlation_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST correlation_name_AST = null;
		
		id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		correlation_name_AST = currentAST.root;
		returnAST = correlation_name_AST;
	}
	
	public void derived_column_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST derived_column_list_AST = null;
		
		column_name_list();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		derived_column_list_AST = currentAST.root;
		returnAST = derived_column_list_AST;
	}
	
	public void outer_join_type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST outer_join_type_AST = null;
		
		if ((LA(1)==SQL2RW_left))
		{
			AST tmp266_AST = null;
			tmp266_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp266_AST);
			match(SQL2RW_left);
			outer_join_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_right)) {
			AST tmp267_AST = null;
			tmp267_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp267_AST);
			match(SQL2RW_right);
			outer_join_type_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_full)) {
			AST tmp268_AST = null;
			tmp268_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp268_AST);
			match(SQL2RW_full);
			outer_join_type_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = outer_join_type_AST;
	}
	
	public void join_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST join_spec_AST = null;
		
		if ((LA(1)==SQL2RW_on))
		{
			join_condition();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			join_spec_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_using)) {
			named_columns_join();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			join_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = join_spec_AST;
	}
	
	public void join_condition() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST join_condition_AST = null;
		
		AST tmp269_AST = null;
		tmp269_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp269_AST);
		match(SQL2RW_on);
		search_condition();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		join_condition_AST = currentAST.root;
		returnAST = join_condition_AST;
	}
	
	public void named_columns_join() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST named_columns_join_AST = null;
		
		AST tmp270_AST = null;
		tmp270_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp270_AST);
		match(SQL2RW_using);
		AST tmp271_AST = null;
		tmp271_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp271_AST);
		match(LEFT_PAREN);
		column_name_list();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp272_AST = null;
		tmp272_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp272_AST);
		match(RIGHT_PAREN);
		named_columns_join_AST = currentAST.root;
		returnAST = named_columns_join_AST;
	}
	
	public QueryExpressionCollection  from_clause() //throws RecognitionException, TokenStreamException
{
		QueryExpressionCollection queryExpressionCollection;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST from_clause_AST = null;
		
		AST tmp273_AST = null;
		tmp273_AST = astFactory.create(LT(1));
		astFactory.makeASTRoot(ref currentAST, tmp273_AST);
		match(SQL2RW_from);
		queryExpressionCollection=table_ref_list();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		from_clause_AST = currentAST.root;
		returnAST = from_clause_AST;
		return queryExpressionCollection;
	}
	
	public IExpression  where_clause() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST where_clause_AST = null;
		
		AST tmp274_AST = null;
		tmp274_AST = astFactory.create(LT(1));
		astFactory.makeASTRoot(ref currentAST, tmp274_AST);
		match(SQL2RW_where);
		expression=search_condition();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		where_clause_AST = currentAST.root;
		returnAST = where_clause_AST;
		return expression;
	}
	
	public void group_by_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST group_by_clause_AST = null;
		
		AST tmp275_AST = null;
		tmp275_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp275_AST);
		match(SQL2RW_group);
		AST tmp276_AST = null;
		tmp276_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp276_AST);
		match(SQL2RW_by);
		grouping_column_ref_list();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		group_by_clause_AST = currentAST.root;
		returnAST = group_by_clause_AST;
	}
	
	public void having_clause() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST having_clause_AST = null;
		
		AST tmp277_AST = null;
		tmp277_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp277_AST);
		match(SQL2RW_having);
		search_condition();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		having_clause_AST = currentAST.root;
		returnAST = having_clause_AST;
	}
	
	public QueryExpressionCollection  table_ref_list() //throws RecognitionException, TokenStreamException
{
		QueryExpressionCollection queryExpressionCollection;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST table_ref_list_AST = null;
		
			queryExpressionCollection = new QueryExpressionCollection();
			IQueryExpression queryExpression = null;
		
		
		queryExpression=table_ref();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			queryExpressionCollection.Add(queryExpression);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp278_AST = null;
					tmp278_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp278_AST);
					match(COMMA);
					queryExpression=table_ref();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						queryExpressionCollection.Add(queryExpression);
					}
				}
				else
				{
					goto _loop334_breakloop;
				}
				
			}
_loop334_breakloop:			;
		}    // ( ... )*
		table_ref_list_AST = currentAST.root;
		returnAST = table_ref_list_AST;
		return queryExpressionCollection;
	}
	
	public void grouping_column_ref_list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST grouping_column_ref_list_AST = null;
		
		grouping_column_ref();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==COMMA))
				{
					AST tmp279_AST = null;
					tmp279_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp279_AST);
					match(COMMA);
					grouping_column_ref();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else
				{
					goto _loop341_breakloop;
				}
				
			}
_loop341_breakloop:			;
		}    // ( ... )*
		grouping_column_ref_list_AST = currentAST.root;
		returnAST = grouping_column_ref_list_AST;
	}
	
	public void grouping_column_ref() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST grouping_column_ref_AST = null;
		
		column_ref();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_collate))
			{
				collate_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_36_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		grouping_column_ref_AST = currentAST.root;
		returnAST = grouping_column_ref_AST;
	}
	
	public string  unsigned_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unsigned_lit_AST = null;
		
		if ((LA(1)==UNSIGNED_INTEGER||LA(1)==APPROXIMATE_NUM_LIT||LA(1)==EXACT_NUM_LIT))
		{
			literal=unsigned_num_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			unsigned_lit_AST = currentAST.root;
		}
		else if ((tokenSet_37_.member(LA(1)))) {
			literal=general_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			unsigned_lit_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = unsigned_lit_AST;
		return literal;
	}
	
	public string  general_value_spec() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST general_value_spec_AST = null;
		
		switch ( LA(1) )
		{
		case COLON:
		{
			parameter_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case QUESTION_MARK:
		{
			dyn_parameter_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case EMBDD_VARIABLE_NAME:
		{
			variable_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case SQL2RW_user:
		{
			AST tmp280_AST = null;
			tmp280_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp280_AST);
			match(SQL2RW_user);
			if (0==inputState.guessing)
			{
				literal = "user";
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case SQL2RW_current_user:
		{
			AST tmp281_AST = null;
			tmp281_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp281_AST);
			match(SQL2RW_current_user);
			if (0==inputState.guessing)
			{
				literal = "current_user";
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case SQL2RW_session_user:
		{
			AST tmp282_AST = null;
			tmp282_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp282_AST);
			match(SQL2RW_session_user);
			if (0==inputState.guessing)
			{
				literal = "session_user";
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case SQL2RW_system_user:
		{
			AST tmp283_AST = null;
			tmp283_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp283_AST);
			match(SQL2RW_system_user);
			if (0==inputState.guessing)
			{
				literal = "system_user";
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		case SQL2RW_value:
		{
			AST tmp284_AST = null;
			tmp284_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp284_AST);
			match(SQL2RW_value);
			if (0==inputState.guessing)
			{
				literal = "value";
			}
			general_value_spec_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = general_value_spec_AST;
		return literal;
	}
	
	public void parameter_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST parameter_spec_AST = null;
		
		parameter_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_indicator||LA(1)==COLON))
			{
				{
					if ((LA(1)==SQL2RW_indicator))
					{
						AST tmp285_AST = null;
						tmp285_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp285_AST);
						match(SQL2RW_indicator);
					}
					else if ((LA(1)==COLON)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				parameter_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_29_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		parameter_spec_AST = currentAST.root;
		returnAST = parameter_spec_AST;
	}
	
	public void dyn_parameter_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST dyn_parameter_spec_AST = null;
		
		AST tmp286_AST = null;
		tmp286_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp286_AST);
		match(QUESTION_MARK);
		dyn_parameter_spec_AST = currentAST.root;
		returnAST = dyn_parameter_spec_AST;
	}
	
	public void variable_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST variable_spec_AST = null;
		
		AST tmp287_AST = null;
		tmp287_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp287_AST);
		match(EMBDD_VARIABLE_NAME);
		{
			if ((LA(1)==SQL2RW_indicator||LA(1)==EMBDD_VARIABLE_NAME))
			{
				{
					if ((LA(1)==SQL2RW_indicator))
					{
						AST tmp288_AST = null;
						tmp288_AST = astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, tmp288_AST);
						match(SQL2RW_indicator);
					}
					else if ((LA(1)==EMBDD_VARIABLE_NAME)) {
					}
					else
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					
				}
				AST tmp289_AST = null;
				tmp289_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp289_AST);
				match(EMBDD_VARIABLE_NAME);
			}
			else if ((tokenSet_29_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		variable_spec_AST = currentAST.root;
		returnAST = variable_spec_AST;
	}
	
	public void parameter_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST parameter_name_AST = null;
		
		AST tmp290_AST = null;
		tmp290_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp290_AST);
		match(COLON);
		{
			if ((LA(1)==SQL2NRW_ada||LA(1)==REGULAR_ID||LA(1)==DELIMITED_ID||LA(1)==INTRODUCER))
			{
				id();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==PERIOD))
						{
							AST tmp291_AST = null;
							tmp291_AST = astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, tmp291_AST);
							match(PERIOD);
							id();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(ref currentAST, returnAST);
							}
						}
						else
						{
							goto _loop425_breakloop;
						}
						
					}
_loop425_breakloop:					;
				}    // ( ... )*
			}
			else if ((LA(1)==UNSIGNED_INTEGER)) {
				AST tmp292_AST = null;
				tmp292_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp292_AST);
				match(UNSIGNED_INTEGER);
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		parameter_name_AST = currentAST.root;
		returnAST = parameter_name_AST;
	}
	
	public IExpression  num_value_exp() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST num_value_exp_AST = null;
		
		expression=value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		num_value_exp_AST = currentAST.root;
		returnAST = num_value_exp_AST;
		return expression;
	}
	
	public IExpression  string_value_exp() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST string_value_exp_AST = null;
		
		expression=char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		string_value_exp_AST = currentAST.root;
		returnAST = string_value_exp_AST;
		return expression;
	}
	
	public IExpression  datetime_value_exp() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST datetime_value_exp_AST = null;
		
		expression=value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		datetime_value_exp_AST = currentAST.root;
		returnAST = datetime_value_exp_AST;
		return expression;
	}
	
	public IExpression  interval_value_exp() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interval_value_exp_AST = null;
		
		expression=value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		interval_value_exp_AST = currentAST.root;
		returnAST = interval_value_exp_AST;
		return expression;
	}
	
	public IExpression  term() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST term_AST = null;
		
			IExpression expressionRhs = null;
		
		
		expression=factor();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{    // ( ... )*
			for (;;)
			{
				if ((LA(1)==ASTERISK||LA(1)==SOLIDUS) && (tokenSet_9_.member(LA(2))))
				{
					factor_op();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					expressionRhs=factor();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
					if (0==inputState.guessing)
					{
						
									ITwoPartExpression twoPartExpression = new TwoPartExpression();
									twoPartExpression.Lhs = expression;
									twoPartExpression.Rhs = expressionRhs;
									expression = twoPartExpression;
								
					}
				}
				else
				{
					goto _loop376_breakloop;
				}
				
			}
_loop376_breakloop:			;
		}    // ( ... )*
		term_AST = currentAST.root;
		returnAST = term_AST;
		return expression;
	}
	
	public void term_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST term_op_AST = null;
		
		if ((LA(1)==PLUS_SIGN))
		{
			AST tmp293_AST = null;
			tmp293_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp293_AST);
			match(PLUS_SIGN);
			term_op_AST = currentAST.root;
		}
		else if ((LA(1)==MINUS_SIGN)) {
			AST tmp294_AST = null;
			tmp294_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp294_AST);
			match(MINUS_SIGN);
			term_op_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = term_op_AST;
	}
	
	public void string_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST string_value_fct_AST = null;
		
		char_value_fct();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		string_value_fct_AST = currentAST.root;
		returnAST = string_value_fct_AST;
	}
	
	public void char_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_value_fct_AST = null;
		
		switch ( LA(1) )
		{
		case SQL2RW_substring:
		{
			char_substring_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			char_value_fct_AST = currentAST.root;
			break;
		}
		case SQL2RW_lower:
		case SQL2RW_upper:
		{
			fold();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			char_value_fct_AST = currentAST.root;
			break;
		}
		case SQL2RW_convert:
		{
			form_conversion();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			char_value_fct_AST = currentAST.root;
			break;
		}
		case SQL2RW_translate:
		{
			char_translation();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			char_value_fct_AST = currentAST.root;
			break;
		}
		case SQL2RW_trim:
		{
			trim_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			char_value_fct_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = char_value_fct_AST;
	}
	
	public void char_substring_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_substring_fct_AST = null;
		
		AST tmp295_AST = null;
		tmp295_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp295_AST);
		match(SQL2RW_substring);
		AST tmp296_AST = null;
		tmp296_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp296_AST);
		match(LEFT_PAREN);
		char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp297_AST = null;
		tmp297_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp297_AST);
		match(SQL2RW_from);
		num_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_for))
			{
				AST tmp298_AST = null;
				tmp298_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp298_AST);
				match(SQL2RW_for);
				num_value_exp();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==RIGHT_PAREN)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		AST tmp299_AST = null;
		tmp299_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp299_AST);
		match(RIGHT_PAREN);
		char_substring_fct_AST = currentAST.root;
		returnAST = char_substring_fct_AST;
	}
	
	public void fold() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST fold_AST = null;
		
		{
			if ((LA(1)==SQL2RW_upper))
			{
				AST tmp300_AST = null;
				tmp300_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp300_AST);
				match(SQL2RW_upper);
			}
			else if ((LA(1)==SQL2RW_lower)) {
				AST tmp301_AST = null;
				tmp301_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp301_AST);
				match(SQL2RW_lower);
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		AST tmp302_AST = null;
		tmp302_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp302_AST);
		match(LEFT_PAREN);
		char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp303_AST = null;
		tmp303_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp303_AST);
		match(RIGHT_PAREN);
		fold_AST = currentAST.root;
		returnAST = fold_AST;
	}
	
	public void form_conversion() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST form_conversion_AST = null;
		
		AST tmp304_AST = null;
		tmp304_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp304_AST);
		match(SQL2RW_convert);
		AST tmp305_AST = null;
		tmp305_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp305_AST);
		match(LEFT_PAREN);
		char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp306_AST = null;
		tmp306_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp306_AST);
		match(SQL2RW_using);
		form_conversion_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp307_AST = null;
		tmp307_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp307_AST);
		match(RIGHT_PAREN);
		form_conversion_AST = currentAST.root;
		returnAST = form_conversion_AST;
	}
	
	public void char_translation() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_translation_AST = null;
		
		AST tmp308_AST = null;
		tmp308_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp308_AST);
		match(SQL2RW_translate);
		AST tmp309_AST = null;
		tmp309_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp309_AST);
		match(LEFT_PAREN);
		char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp310_AST = null;
		tmp310_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp310_AST);
		match(SQL2RW_using);
		translation_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp311_AST = null;
		tmp311_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp311_AST);
		match(RIGHT_PAREN);
		char_translation_AST = currentAST.root;
		returnAST = char_translation_AST;
	}
	
	public void trim_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST trim_fct_AST = null;
		
		AST tmp312_AST = null;
		tmp312_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp312_AST);
		match(SQL2RW_trim);
		AST tmp313_AST = null;
		tmp313_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp313_AST);
		match(LEFT_PAREN);
		trim_operands();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp314_AST = null;
		tmp314_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp314_AST);
		match(RIGHT_PAREN);
		trim_fct_AST = currentAST.root;
		returnAST = trim_fct_AST;
	}
	
	public void form_conversion_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST form_conversion_name_AST = null;
		
		qualified_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		form_conversion_name_AST = currentAST.root;
		returnAST = form_conversion_name_AST;
	}
	
	public void translation_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST translation_name_AST = null;
		
		qualified_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		translation_name_AST = currentAST.root;
		returnAST = translation_name_AST;
	}
	
	public void trim_operands() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST trim_operands_AST = null;
		
		if ((LA(1)==SQL2RW_both||LA(1)==SQL2RW_leading||LA(1)==SQL2RW_trailing) && (LA(2)==SQL2RW_from))
		{
			trim_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp315_AST = null;
			tmp315_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp315_AST);
			match(SQL2RW_from);
			char_value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			trim_operands_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_both||LA(1)==SQL2RW_leading||LA(1)==SQL2RW_trailing) && (tokenSet_9_.member(LA(2)))) {
			trim_spec();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			char_value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			AST tmp316_AST = null;
			tmp316_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp316_AST);
			match(SQL2RW_from);
			char_value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			trim_operands_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_from)) {
			AST tmp317_AST = null;
			tmp317_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp317_AST);
			match(SQL2RW_from);
			char_value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			trim_operands_AST = currentAST.root;
		}
		else if ((tokenSet_9_.member(LA(1)))) {
			char_value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				if ((LA(1)==SQL2RW_from))
				{
					AST tmp318_AST = null;
					tmp318_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp318_AST);
					match(SQL2RW_from);
					char_value_exp();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((LA(1)==RIGHT_PAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			trim_operands_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = trim_operands_AST;
	}
	
	public void trim_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST trim_spec_AST = null;
		
		if ((LA(1)==SQL2RW_leading))
		{
			AST tmp319_AST = null;
			tmp319_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp319_AST);
			match(SQL2RW_leading);
			trim_spec_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_trailing)) {
			AST tmp320_AST = null;
			tmp320_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp320_AST);
			match(SQL2RW_trailing);
			trim_spec_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_both)) {
			AST tmp321_AST = null;
			tmp321_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp321_AST);
			match(SQL2RW_both);
			trim_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = trim_spec_AST;
	}
	
	public IExpression  factor() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST factor_AST = null;
		
		{
			if ((LA(1)==MINUS_SIGN||LA(1)==PLUS_SIGN))
			{
				sign();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_38_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		expression=gen_primary();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==SQL2RW_at))
			{
				AST tmp322_AST = null;
				tmp322_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp322_AST);
				match(SQL2RW_at);
				time_zone_specifier();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==SQL2RW_collate)) {
				collate_clause();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((tokenSet_39_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		factor_AST = currentAST.root;
		returnAST = factor_AST;
		return expression;
	}
	
	public void factor_op() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST factor_op_AST = null;
		
		if ((LA(1)==ASTERISK))
		{
			AST tmp323_AST = null;
			tmp323_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp323_AST);
			match(ASTERISK);
			factor_op_AST = currentAST.root;
		}
		else if ((LA(1)==SOLIDUS)) {
			AST tmp324_AST = null;
			tmp324_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp324_AST);
			match(SOLIDUS);
			factor_op_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = factor_op_AST;
	}
	
	public string  sign() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST sign_AST = null;
		
		if ((LA(1)==PLUS_SIGN))
		{
			AST tmp325_AST = null;
			tmp325_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp325_AST);
			match(PLUS_SIGN);
			if (0==inputState.guessing)
			{
				literal="+";
			}
			sign_AST = currentAST.root;
		}
		else if ((LA(1)==MINUS_SIGN)) {
			AST tmp326_AST = null;
			tmp326_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp326_AST);
			match(MINUS_SIGN);
			if (0==inputState.guessing)
			{
				literal="-";
			}
			sign_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = sign_AST;
		return literal;
	}
	
	public IExpression  gen_primary() //throws RecognitionException, TokenStreamException
{
		IExpression expression = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST gen_primary_AST = null;
		
		switch ( LA(1) )
		{
		case SQL2NRW_ada:
		case SQL2RW_avg:
		case SQL2RW_case:
		case SQL2RW_cast:
		case SQL2RW_coalesce:
		case SQL2RW_count:
		case SQL2RW_current_user:
		case SQL2RW_date:
		case SQL2RW_interval:
		case SQL2RW_max:
		case SQL2RW_min:
		case SQL2RW_nullif:
		case SQL2RW_session_user:
		case SQL2RW_sum:
		case SQL2RW_system_user:
		case SQL2RW_time:
		case SQL2RW_timestamp:
		case SQL2RW_user:
		case SQL2RW_value:
		case UNSIGNED_INTEGER:
		case APPROXIMATE_NUM_LIT:
		case NATIONAL_CHAR_STRING_LIT:
		case BIT_STRING_LIT:
		case HEX_STRING_LIT:
		case EMBDD_VARIABLE_NAME:
		case REGULAR_ID:
		case EXACT_NUM_LIT:
		case CHAR_STRING:
		case DELIMITED_ID:
		case LEFT_PAREN:
		case COLON:
		case QUESTION_MARK:
		case INTRODUCER:
		{
			expression=value_exp_primary();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			{
				if ((LA(1)==SQL2RW_day||LA(1)==SQL2RW_hour||LA(1)==SQL2RW_minute||LA(1)==SQL2RW_month||LA(1)==SQL2RW_second||LA(1)==SQL2RW_year))
				{
					interval_qualifier();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, returnAST);
					}
				}
				else if ((tokenSet_40_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			gen_primary_AST = currentAST.root;
			break;
		}
		case SQL2RW_bit_length:
		case SQL2RW_char_length:
		case SQL2RW_character_length:
		case SQL2RW_extract:
		case SQL2RW_octet_length:
		case SQL2RW_position:
		{
			num_value_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			gen_primary_AST = currentAST.root;
			break;
		}
		case SQL2RW_convert:
		case SQL2RW_lower:
		case SQL2RW_substring:
		case SQL2RW_translate:
		case SQL2RW_trim:
		case SQL2RW_upper:
		{
			string_value_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			gen_primary_AST = currentAST.root;
			break;
		}
		case SQL2RW_current_date:
		case SQL2RW_current_time:
		case SQL2RW_current_timestamp:
		{
			datetime_value_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			gen_primary_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = gen_primary_AST;
		return expression;
	}
	
	public void time_zone_specifier() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST time_zone_specifier_AST = null;
		
		if ((LA(1)==SQL2RW_local))
		{
			AST tmp327_AST = null;
			tmp327_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp327_AST);
			match(SQL2RW_local);
			time_zone_specifier_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_time)) {
			AST tmp328_AST = null;
			tmp328_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp328_AST);
			match(SQL2RW_time);
			AST tmp329_AST = null;
			tmp329_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp329_AST);
			match(SQL2RW_zone);
			interval_value_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			time_zone_specifier_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = time_zone_specifier_AST;
	}
	
	public void collation_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST collation_name_AST = null;
		
		qualified_name();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		collation_name_AST = currentAST.root;
		returnAST = collation_name_AST;
	}
	
	public void num_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST num_value_fct_AST = null;
		
		if ((LA(1)==SQL2RW_position))
		{
			position_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			num_value_fct_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_extract)) {
			extract_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			num_value_fct_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_bit_length||LA(1)==SQL2RW_char_length||LA(1)==SQL2RW_character_length||LA(1)==SQL2RW_octet_length)) {
			length_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			num_value_fct_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = num_value_fct_AST;
	}
	
	public void datetime_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST datetime_value_fct_AST = null;
		
		if ((LA(1)==SQL2RW_current_date))
		{
			current_date_value_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_value_fct_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_current_time)) {
			current_time_value_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_value_fct_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_current_timestamp)) {
			currenttimestamp_value_fct();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_value_fct_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = datetime_value_fct_AST;
	}
	
	public void position_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST position_exp_AST = null;
		
		AST tmp330_AST = null;
		tmp330_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp330_AST);
		match(SQL2RW_position);
		AST tmp331_AST = null;
		tmp331_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp331_AST);
		match(LEFT_PAREN);
		char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp332_AST = null;
		tmp332_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp332_AST);
		match(SQL2RW_in);
		char_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp333_AST = null;
		tmp333_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp333_AST);
		match(RIGHT_PAREN);
		position_exp_AST = currentAST.root;
		returnAST = position_exp_AST;
	}
	
	public void extract_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST extract_exp_AST = null;
		
		AST tmp334_AST = null;
		tmp334_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp334_AST);
		match(SQL2RW_extract);
		AST tmp335_AST = null;
		tmp335_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp335_AST);
		match(LEFT_PAREN);
		extract_field();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp336_AST = null;
		tmp336_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp336_AST);
		match(SQL2RW_from);
		extract_source();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp337_AST = null;
		tmp337_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp337_AST);
		match(RIGHT_PAREN);
		extract_exp_AST = currentAST.root;
		returnAST = extract_exp_AST;
	}
	
	public void length_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST length_exp_AST = null;
		
		if ((LA(1)==SQL2RW_char_length||LA(1)==SQL2RW_character_length))
		{
			char_length_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			length_exp_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_octet_length)) {
			octet_length_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			length_exp_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_bit_length)) {
			bit_length_exp();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			length_exp_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = length_exp_AST;
	}
	
	public void extract_field() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST extract_field_AST = null;
		
		if ((LA(1)==SQL2RW_day||LA(1)==SQL2RW_hour||LA(1)==SQL2RW_minute||LA(1)==SQL2RW_month||LA(1)==SQL2RW_second||LA(1)==SQL2RW_year))
		{
			datetime_field();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			extract_field_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_timezone_hour||LA(1)==SQL2RW_timezone_minute)) {
			time_zone_field();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			extract_field_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = extract_field_AST;
	}
	
	public void extract_source() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST extract_source_AST = null;
		
		datetime_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		extract_source_AST = currentAST.root;
		returnAST = extract_source_AST;
	}
	
	public void datetime_field() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST datetime_field_AST = null;
		
		if ((LA(1)==SQL2RW_day||LA(1)==SQL2RW_hour||LA(1)==SQL2RW_minute||LA(1)==SQL2RW_month||LA(1)==SQL2RW_year))
		{
			non_second_datetime_field();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_field_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_second)) {
			AST tmp338_AST = null;
			tmp338_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp338_AST);
			match(SQL2RW_second);
			datetime_field_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = datetime_field_AST;
	}
	
	public void time_zone_field() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST time_zone_field_AST = null;
		
		if ((LA(1)==SQL2RW_timezone_hour))
		{
			AST tmp339_AST = null;
			tmp339_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp339_AST);
			match(SQL2RW_timezone_hour);
			time_zone_field_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_timezone_minute)) {
			AST tmp340_AST = null;
			tmp340_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp340_AST);
			match(SQL2RW_timezone_minute);
			time_zone_field_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = time_zone_field_AST;
	}
	
	public void non_second_datetime_field() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST non_second_datetime_field_AST = null;
		
		switch ( LA(1) )
		{
		case SQL2RW_year:
		{
			AST tmp341_AST = null;
			tmp341_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp341_AST);
			match(SQL2RW_year);
			non_second_datetime_field_AST = currentAST.root;
			break;
		}
		case SQL2RW_month:
		{
			AST tmp342_AST = null;
			tmp342_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp342_AST);
			match(SQL2RW_month);
			non_second_datetime_field_AST = currentAST.root;
			break;
		}
		case SQL2RW_day:
		{
			AST tmp343_AST = null;
			tmp343_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp343_AST);
			match(SQL2RW_day);
			non_second_datetime_field_AST = currentAST.root;
			break;
		}
		case SQL2RW_hour:
		{
			AST tmp344_AST = null;
			tmp344_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp344_AST);
			match(SQL2RW_hour);
			non_second_datetime_field_AST = currentAST.root;
			break;
		}
		case SQL2RW_minute:
		{
			AST tmp345_AST = null;
			tmp345_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp345_AST);
			match(SQL2RW_minute);
			non_second_datetime_field_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = non_second_datetime_field_AST;
	}
	
	public void char_length_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_length_exp_AST = null;
		
		{
			if ((LA(1)==SQL2RW_char_length))
			{
				AST tmp346_AST = null;
				tmp346_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp346_AST);
				match(SQL2RW_char_length);
			}
			else if ((LA(1)==SQL2RW_character_length)) {
				AST tmp347_AST = null;
				tmp347_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp347_AST);
				match(SQL2RW_character_length);
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		AST tmp348_AST = null;
		tmp348_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp348_AST);
		match(LEFT_PAREN);
		string_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp349_AST = null;
		tmp349_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp349_AST);
		match(RIGHT_PAREN);
		char_length_exp_AST = currentAST.root;
		returnAST = char_length_exp_AST;
	}
	
	public void octet_length_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST octet_length_exp_AST = null;
		
		AST tmp350_AST = null;
		tmp350_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp350_AST);
		match(SQL2RW_octet_length);
		AST tmp351_AST = null;
		tmp351_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp351_AST);
		match(LEFT_PAREN);
		string_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp352_AST = null;
		tmp352_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp352_AST);
		match(RIGHT_PAREN);
		octet_length_exp_AST = currentAST.root;
		returnAST = octet_length_exp_AST;
	}
	
	public void bit_length_exp() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST bit_length_exp_AST = null;
		
		AST tmp353_AST = null;
		tmp353_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp353_AST);
		match(SQL2RW_bit_length);
		AST tmp354_AST = null;
		tmp354_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp354_AST);
		match(LEFT_PAREN);
		string_value_exp();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		AST tmp355_AST = null;
		tmp355_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp355_AST);
		match(RIGHT_PAREN);
		bit_length_exp_AST = currentAST.root;
		returnAST = bit_length_exp_AST;
	}
	
	public void current_date_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST current_date_value_fct_AST = null;
		
		AST tmp356_AST = null;
		tmp356_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp356_AST);
		match(SQL2RW_current_date);
		current_date_value_fct_AST = currentAST.root;
		returnAST = current_date_value_fct_AST;
	}
	
	public void current_time_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST current_time_value_fct_AST = null;
		
		AST tmp357_AST = null;
		tmp357_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp357_AST);
		match(SQL2RW_current_time);
		{
			if ((LA(1)==LEFT_PAREN))
			{
				AST tmp358_AST = null;
				tmp358_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp358_AST);
				match(LEFT_PAREN);
				time_precision();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp359_AST = null;
				tmp359_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp359_AST);
				match(RIGHT_PAREN);
			}
			else if ((tokenSet_40_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		current_time_value_fct_AST = currentAST.root;
		returnAST = current_time_value_fct_AST;
	}
	
	public void currenttimestamp_value_fct() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST currenttimestamp_value_fct_AST = null;
		
		AST tmp360_AST = null;
		tmp360_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp360_AST);
		match(SQL2RW_current_timestamp);
		{
			if ((LA(1)==LEFT_PAREN))
			{
				AST tmp361_AST = null;
				tmp361_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp361_AST);
				match(LEFT_PAREN);
				timestamp_precision();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				AST tmp362_AST = null;
				tmp362_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp362_AST);
				match(RIGHT_PAREN);
			}
			else if ((tokenSet_40_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		currenttimestamp_value_fct_AST = currentAST.root;
		returnAST = currenttimestamp_value_fct_AST;
	}
	
	public string  qualified_local_table_name() //throws RecognitionException, TokenStreamException
{
		 string tableName = null ;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST qualified_local_table_name_AST = null;
		
			string strId;
		
		
		AST tmp363_AST = null;
		tmp363_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp363_AST);
		match(SQL2RW_module);
		AST tmp364_AST = null;
		tmp364_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp364_AST);
		match(PERIOD);
		strId=id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			tableName+="module."; tableName+=strId;
		}
		qualified_local_table_name_AST = currentAST.root;
		returnAST = qualified_local_table_name_AST;
		return tableName;
	}
	
	public void extended_cursor_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST extended_cursor_name_AST = null;
		
		{
			if ((LA(1)==SQL2RW_global))
			{
				AST tmp365_AST = null;
				tmp365_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp365_AST);
				match(SQL2RW_global);
			}
			else if ((LA(1)==SQL2RW_local)) {
				AST tmp366_AST = null;
				tmp366_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp366_AST);
				match(SQL2RW_local);
			}
			else if ((tokenSet_41_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		simple_value_spec();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		extended_cursor_name_AST = currentAST.root;
		returnAST = extended_cursor_name_AST;
	}
	
	public void simple_value_spec() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST simple_value_spec_AST = null;
		
		if ((LA(1)==COLON))
		{
			parameter_name();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			simple_value_spec_AST = currentAST.root;
		}
		else if ((LA(1)==EMBDD_VARIABLE_NAME)) {
			AST tmp367_AST = null;
			tmp367_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp367_AST);
			match(EMBDD_VARIABLE_NAME);
			simple_value_spec_AST = currentAST.root;
		}
		else if ((tokenSet_42_.member(LA(1)))) {
			lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			simple_value_spec_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = simple_value_spec_AST;
	}
	
	public string  lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST lit_AST = null;
		
		if ((LA(1)==UNSIGNED_INTEGER||LA(1)==APPROXIMATE_NUM_LIT||LA(1)==MINUS_SIGN||LA(1)==EXACT_NUM_LIT||LA(1)==PLUS_SIGN))
		{
			literal=signed_num_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			lit_AST = currentAST.root;
		}
		else if ((tokenSet_37_.member(LA(1)))) {
			literal=general_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			lit_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = lit_AST;
		return literal;
	}
	
	public void stmt_name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST stmt_name_AST = null;
		
		id();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		stmt_name_AST = currentAST.root;
		returnAST = stmt_name_AST;
	}
	
	public string  unsigned_num_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST unsigned_num_lit_AST = null;
		IToken  num1 = null;
		AST num1_AST = null;
		IToken  num2 = null;
		AST num2_AST = null;
		IToken  num3 = null;
		AST num3_AST = null;
		
		if ((LA(1)==UNSIGNED_INTEGER))
		{
			num1 = LT(1);
			num1_AST = astFactory.create(num1);
			astFactory.addASTChild(ref currentAST, num1_AST);
			match(UNSIGNED_INTEGER);
			if (0==inputState.guessing)
			{
				literal = num1.getText();
			}
			unsigned_num_lit_AST = currentAST.root;
		}
		else if ((LA(1)==EXACT_NUM_LIT)) {
			num2 = LT(1);
			num2_AST = astFactory.create(num2);
			astFactory.addASTChild(ref currentAST, num2_AST);
			match(EXACT_NUM_LIT);
			if (0==inputState.guessing)
			{
				literal = num2.getText();
			}
			unsigned_num_lit_AST = currentAST.root;
		}
		else if ((LA(1)==APPROXIMATE_NUM_LIT)) {
			num3 = LT(1);
			num3_AST = astFactory.create(num3);
			astFactory.addASTChild(ref currentAST, num3_AST);
			match(APPROXIMATE_NUM_LIT);
			if (0==inputState.guessing)
			{
				literal = num3.getText();
			}
			unsigned_num_lit_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = unsigned_num_lit_AST;
		return literal;
	}
	
	public string  char_string_lit() //throws RecognitionException, TokenStreamException
{
		string strLiteral = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST char_string_lit_AST = null;
		IToken  literal = null;
		AST literal_AST = null;
		
		{
			if ((LA(1)==INTRODUCER))
			{
				AST tmp368_AST = null;
				tmp368_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp368_AST);
				match(INTRODUCER);
				char_set_name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==CHAR_STRING)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		literal = LT(1);
		literal_AST = astFactory.create(literal);
		astFactory.addASTChild(ref currentAST, literal_AST);
		match(CHAR_STRING);
		if (0==inputState.guessing)
		{
			strLiteral = literal.getText();
		}
		char_string_lit_AST = currentAST.root;
		returnAST = char_string_lit_AST;
		return strLiteral;
	}
	
	public string  general_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST general_lit_AST = null;
		IToken  charStringLiteral = null;
		AST charStringLiteral_AST = null;
		IToken  bitStringLiteral = null;
		AST bitStringLiteral_AST = null;
		IToken  hexStringLiteral = null;
		AST hexStringLiteral_AST = null;
		
		switch ( LA(1) )
		{
		case CHAR_STRING:
		case INTRODUCER:
		{
			literal=char_string_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			general_lit_AST = currentAST.root;
			break;
		}
		case NATIONAL_CHAR_STRING_LIT:
		{
			charStringLiteral = LT(1);
			charStringLiteral_AST = astFactory.create(charStringLiteral);
			astFactory.addASTChild(ref currentAST, charStringLiteral_AST);
			match(NATIONAL_CHAR_STRING_LIT);
			if (0==inputState.guessing)
			{
				literal = charStringLiteral.getText();
			}
			general_lit_AST = currentAST.root;
			break;
		}
		case BIT_STRING_LIT:
		{
			bitStringLiteral = LT(1);
			bitStringLiteral_AST = astFactory.create(bitStringLiteral);
			astFactory.addASTChild(ref currentAST, bitStringLiteral_AST);
			match(BIT_STRING_LIT);
			if (0==inputState.guessing)
			{
				literal = bitStringLiteral.getText();
			}
			general_lit_AST = currentAST.root;
			break;
		}
		case HEX_STRING_LIT:
		{
			hexStringLiteral = LT(1);
			hexStringLiteral_AST = astFactory.create(hexStringLiteral);
			astFactory.addASTChild(ref currentAST, hexStringLiteral_AST);
			match(HEX_STRING_LIT);
			if (0==inputState.guessing)
			{
				literal = hexStringLiteral.getText();
			}
			general_lit_AST = currentAST.root;
			break;
		}
		case SQL2RW_date:
		case SQL2RW_time:
		case SQL2RW_timestamp:
		{
			literal=datetime_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			general_lit_AST = currentAST.root;
			break;
		}
		case SQL2RW_interval:
		{
			literal=interval_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			general_lit_AST = currentAST.root;
			break;
		}
		default:
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		 }
		returnAST = general_lit_AST;
		return literal;
	}
	
	public string  datetime_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST datetime_lit_AST = null;
		
		if ((LA(1)==SQL2RW_date))
		{
			literal=date_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_lit_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_time)) {
			literal=time_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_lit_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_timestamp)) {
			literal=timestamp_lit();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			datetime_lit_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = datetime_lit_AST;
		return literal;
	}
	
	public string  interval_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST interval_lit_AST = null;
		IToken  charString = null;
		AST charString_AST = null;
		
		AST tmp369_AST = null;
		tmp369_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp369_AST);
		match(SQL2RW_interval);
		{
			if ((LA(1)==MINUS_SIGN||LA(1)==PLUS_SIGN))
			{
				sign();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
			}
			else if ((LA(1)==CHAR_STRING)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		charString = LT(1);
		charString_AST = astFactory.create(charString);
		astFactory.addASTChild(ref currentAST, charString_AST);
		match(CHAR_STRING);
		interval_qualifier();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			literal = charString.getText();
		}
		interval_lit_AST = currentAST.root;
		returnAST = interval_lit_AST;
		return literal;
	}
	
	public string  date_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST date_lit_AST = null;
		IToken  charString = null;
		AST charString_AST = null;
		
		AST tmp370_AST = null;
		tmp370_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp370_AST);
		match(SQL2RW_date);
		charString = LT(1);
		charString_AST = astFactory.create(charString);
		astFactory.addASTChild(ref currentAST, charString_AST);
		match(CHAR_STRING);
		if (0==inputState.guessing)
		{
			literal = charString.getText();
		}
		date_lit_AST = currentAST.root;
		returnAST = date_lit_AST;
		return literal;
	}
	
	public string  time_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST time_lit_AST = null;
		IToken  charString = null;
		AST charString_AST = null;
		
		AST tmp371_AST = null;
		tmp371_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp371_AST);
		match(SQL2RW_time);
		charString = LT(1);
		charString_AST = astFactory.create(charString);
		astFactory.addASTChild(ref currentAST, charString_AST);
		match(CHAR_STRING);
		if (0==inputState.guessing)
		{
			literal = charString.getText();
		}
		time_lit_AST = currentAST.root;
		returnAST = time_lit_AST;
		return literal;
	}
	
	public string  timestamp_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST timestamp_lit_AST = null;
		IToken  charString = null;
		AST charString_AST = null;
		
		AST tmp372_AST = null;
		tmp372_AST = astFactory.create(LT(1));
		astFactory.addASTChild(ref currentAST, tmp372_AST);
		match(SQL2RW_timestamp);
		charString = LT(1);
		charString_AST = astFactory.create(charString);
		astFactory.addASTChild(ref currentAST, charString_AST);
		match(CHAR_STRING);
		if (0==inputState.guessing)
		{
			literal = charString.getText();
		}
		timestamp_lit_AST = currentAST.root;
		returnAST = timestamp_lit_AST;
		return literal;
	}
	
	public void start_field() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST start_field_AST = null;
		
		non_second_datetime_field();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		{
			if ((LA(1)==LEFT_PAREN))
			{
				AST tmp373_AST = null;
				tmp373_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp373_AST);
				match(LEFT_PAREN);
				AST tmp374_AST = null;
				tmp374_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp374_AST);
				match(UNSIGNED_INTEGER);
				AST tmp375_AST = null;
				tmp375_AST = astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, tmp375_AST);
				match(RIGHT_PAREN);
			}
			else if ((tokenSet_43_.member(LA(1)))) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		start_field_AST = currentAST.root;
		returnAST = start_field_AST;
	}
	
	public void end_field() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST end_field_AST = null;
		
		if ((LA(1)==SQL2RW_day||LA(1)==SQL2RW_hour||LA(1)==SQL2RW_minute||LA(1)==SQL2RW_month||LA(1)==SQL2RW_year))
		{
			non_second_datetime_field();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, returnAST);
			}
			end_field_AST = currentAST.root;
		}
		else if ((LA(1)==SQL2RW_second)) {
			AST tmp376_AST = null;
			tmp376_AST = astFactory.create(LT(1));
			astFactory.addASTChild(ref currentAST, tmp376_AST);
			match(SQL2RW_second);
			{
				if ((LA(1)==LEFT_PAREN))
				{
					AST tmp377_AST = null;
					tmp377_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp377_AST);
					match(LEFT_PAREN);
					AST tmp378_AST = null;
					tmp378_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp378_AST);
					match(UNSIGNED_INTEGER);
					AST tmp379_AST = null;
					tmp379_AST = astFactory.create(LT(1));
					astFactory.addASTChild(ref currentAST, tmp379_AST);
					match(RIGHT_PAREN);
				}
				else if ((tokenSet_29_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			end_field_AST = currentAST.root;
		}
		else
		{
			throw new NoViableAltException(LT(1), getFilename());
		}
		
		returnAST = end_field_AST;
	}
	
	public string  signed_num_lit() //throws RecognitionException, TokenStreamException
{
		string literal = null;
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		AST signed_num_lit_AST = null;
		string tmp;
		
		{
			if ((LA(1)==MINUS_SIGN||LA(1)==PLUS_SIGN))
			{
				tmp=sign();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, returnAST);
				}
				if (0==inputState.guessing)
				{
					literal+=tmp;
				}
			}
			else if ((LA(1)==UNSIGNED_INTEGER||LA(1)==APPROXIMATE_NUM_LIT||LA(1)==EXACT_NUM_LIT)) {
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		tmp=unsigned_num_lit();
		if (0 == inputState.guessing)
		{
			astFactory.addASTChild(ref currentAST, returnAST);
		}
		if (0==inputState.guessing)
		{
			literal+=tmp;
		}
		signed_num_lit_AST = currentAST.root;
		returnAST = signed_num_lit_AST;
		return literal;
	}
	
	private void initializeFactory()
	{
		if (astFactory == null)
		{
			astFactory = new ASTFactory();
		}
		initializeASTFactory( astFactory );
	}
	static public void initializeASTFactory( ASTFactory factory )
	{
		factory.setMaxNodeType(326);
	}
	
	public static readonly string[] tokenNames_ = new string[] {
		@"""<0>""",
		@"""EOF""",
		@"""<2>""",
		@"""NULL_TREE_LOOKAHEAD""",
		@"""<4>""",
		@"""ada""",
		@"""c""",
		@"""catalog_name""",
		@"""character_set_catalog""",
		@"""character_set_name""",
		@"""character_set_schema""",
		@"""class_origin""",
		@"""cobol""",
		@"""collation_catalog""",
		@"""collation_name""",
		@"""collation_schema""",
		@"""column_name""",
		@"""command_function""",
		@"""committed""",
		@"""condition_number""",
		@"""connection_name""",
		@"""constraint_catalog""",
		@"""constraint_name""",
		@"""constraint_schema""",
		@"""cursor_name""",
		@"""data""",
		@"""datetime_interval_code""",
		@"""datetime_interval_precision""",
		@"""dynamic_function""",
		@"""fortran""",
		@"""length""",
		@"""message_length""",
		@"""message_octet_length""",
		@"""message_text""",
		@"""more""",
		@"""mumps""",
		@"""name""",
		@"""nullable""",
		@"""number""",
		@"""pascal""",
		@"""pli""",
		@"""repeatable""",
		@"""returned_length""",
		@"""returned_octet_length""",
		@"""returned_sqlstate""",
		@"""row_count""",
		@"""scale""",
		@"""schema_name""",
		@"""serializable""",
		@"""server_name""",
		@"""subclass_origin""",
		@"""table_name""",
		@"""type""",
		@"""uncommitted""",
		@"""unnamed""",
		@"""absolute""",
		@"""action""",
		@"""add""",
		@"""all""",
		@"""allocate""",
		@"""alter""",
		@"""and""",
		@"""any""",
		@"""are""",
		@"""as""",
		@"""asc""",
		@"""assertion""",
		@"""at""",
		@"""authorization""",
		@"""avg""",
		@"""begin""",
		@"""between""",
		@"""bit""",
		@"""bit_length""",
		@"""both""",
		@"""by""",
		@"""cascade""",
		@"""cascaded""",
		@"""case""",
		@"""cast""",
		@"""catalog""",
		@"""char""",
		@"""character""",
		@"""char_length""",
		@"""character_length""",
		@"""check""",
		@"""close""",
		@"""coalesce""",
		@"""collate""",
		@"""collation""",
		@"""column""",
		@"""commit""",
		@"""connect""",
		@"""connection""",
		@"""constraint""",
		@"""constraints""",
		@"""continue""",
		@"""convert""",
		@"""corresponding""",
		@"""count""",
		@"""create""",
		@"""cross""",
		@"""current""",
		@"""current_date""",
		@"""current_time""",
		@"""current_timestamp""",
		@"""current_user""",
		@"""cursor""",
		@"""date""",
		@"""day""",
		@"""deallocate""",
		@"""dec""",
		@"""decimal""",
		@"""declare""",
		@"""default""",
		@"""deferrable""",
		@"""deferred""",
		@"""delete""",
		@"""desc""",
		@"""describe""",
		@"""descriptor""",
		@"""diagnostics""",
		@"""disconnect""",
		@"""distinct""",
		@"""domain""",
		@"""double""",
		@"""drop""",
		@"""else""",
		@"""end""",
		@"""end-exec""",
		@"""escape""",
		@"""except""",
		@"""exception""",
		@"""exec""",
		@"""execute""",
		@"""exists""",
		@"""external""",
		@"""extract""",
		@"""false""",
		@"""fetch""",
		@"""first""",
		@"""float""",
		@"""for""",
		@"""foreign""",
		@"""found""",
		@"""from""",
		@"""full""",
		@"""get""",
		@"""global""",
		@"""go""",
		@"""goto""",
		@"""grant""",
		@"""group""",
		@"""having""",
		@"""hour""",
		@"""identity""",
		@"""immediate""",
		@"""in""",
		@"""indicator""",
		@"""initially""",
		@"""inner""",
		@"""input""",
		@"""insensitive""",
		@"""insert""",
		@"""int""",
		@"""integer""",
		@"""intersect""",
		@"""interval""",
		@"""into""",
		@"""is""",
		@"""isolation""",
		@"""join""",
		@"""key""",
		@"""language""",
		@"""last""",
		@"""leading""",
		@"""left""",
		@"""level""",
		@"""like""",
		@"""local""",
		@"""lower""",
		@"""match""",
		@"""max""",
		@"""min""",
		@"""minute""",
		@"""module""",
		@"""month""",
		@"""names""",
		@"""national""",
		@"""natural""",
		@"""nchar""",
		@"""next""",
		@"""no""",
		@"""not""",
		@"""null""",
		@"""nullif""",
		@"""numeric""",
		@"""octet_length""",
		@"""of""",
		@"""on""",
		@"""only""",
		@"""open""",
		@"""option""",
		@"""or""",
		@"""order""",
		@"""outer""",
		@"""output""",
		@"""overlaps""",
		@"""pad""",
		@"""partial""",
		@"""position""",
		@"""precision""",
		@"""prepare""",
		@"""preserve""",
		@"""primary""",
		@"""prior""",
		@"""privileges""",
		@"""procedure""",
		@"""public""",
		@"""read""",
		@"""real""",
		@"""references""",
		@"""relative""",
		@"""restrict""",
		@"""revoke""",
		@"""right""",
		@"""rollback""",
		@"""rows""",
		@"""schema""",
		@"""scroll""",
		@"""second""",
		@"""section""",
		@"""select""",
		@"""session""",
		@"""session_user""",
		@"""set""",
		@"""size""",
		@"""smallint""",
		@"""some""",
		@"""space""",
		@"""sql""",
		@"""sqlcode""",
		@"""sqlerror""",
		@"""sqlstate""",
		@"""substring""",
		@"""sum""",
		@"""system_user""",
		@"""table""",
		@"""temporary""",
		@"""then""",
		@"""time""",
		@"""timestamp""",
		@"""timezone_hour""",
		@"""timezone_minute""",
		@"""to""",
		@"""trailing""",
		@"""transaction""",
		@"""translate""",
		@"""translation""",
		@"""trim""",
		@"""true""",
		@"""union""",
		@"""unique""",
		@"""unknown""",
		@"""update""",
		@"""upper""",
		@"""usage""",
		@"""user""",
		@"""using""",
		@"""value""",
		@"""values""",
		@"""varchar""",
		@"""varying""",
		@"""view""",
		@"""when""",
		@"""whenever""",
		@"""where""",
		@"""with""",
		@"""work""",
		@"""write""",
		@"""year""",
		@"""zone""",
		@"""an integer number""",
		@"""a number""",
		@"""'""",
		@""".""",
		@"""-""",
		@"""_""",
		@"""..""",
		@"""<>""",
		@"""<=""",
		@""">=""",
		@"""||""",
		@"""a national character string""",
		@"""a bit string""",
		@"""a hexadecimal string""",
		@"""an embedded variable""",
		@"""an identifier""",
		@"""a number""",
		@"""a character string""",
		@"""a delimited identifier""",
		@"""%""",
		@"""&""",
		@"""(""",
		@""")""",
		@"""*""",
		@"""+""",
		@""",""",
		@"""/""",
		@""":""",
		@""";""",
		@"""<""",
		@"""=""",
		@""">""",
		@"""?""",
		@"""|""",
		@"""[""",
		@"""]""",
		@"""introducing _""",
		@"""a letter""",
		@"""a separator""",
		@"""a comment""",
		@"""the new line character""",
		@"""the space character""",
		@"""any character""",
		@"""DOUBLE_QUOTE""",
		@"""DOLLAR_SIGN"""
	};
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=9007199254740992L;
		data[2]=144115222435594240L;
		data[3]=36029896530591744L;
		data[4]=4611846547125059840L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=1151781389779488L;
		data[2]=58547344911630976L;
		data[3]=896220723893501998L;
		data[4]=4910225279437253194L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=17179869184L;
		data[2]=144115188075855872L;
		data[3]=36029896530591744L;
		data[4]=4611846547125059584L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=0L;
		data[2]=144115188075855872L;
		data[3]=36029896530591744L;
		data[4]=4611846547125059584L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=-9205322316517474165L;
		data[2]=2676557927997128717L;
		data[3]=144115471543736450L;
		data[4]=278941831861112864L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = new long[10];
		data[0]=288230376151711778L;
		data[1]=577612671132156449L;
		data[2]=2508796092444049928L;
		data[3]=932250629014028332L;
		data[4]=4928802628437043754L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=17592186044416L;
		data[2]=2252349570547712L;
		data[3]=864691128455135232L;
		data[4]=4621854165797175296L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	private static long[] mk_tokenSet_7_()
	{
		long[] data = new long[10];
		data[0]=34L;
		data[1]=17592186044416L;
		data[2]=549755813888L;
		data[3]=864691128455135232L;
		data[4]=4639868564306657280L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
	private static long[] mk_tokenSet_8_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=17592186044416L;
		data[2]=2252349570547712L;
		data[3]=864691128455135232L;
		data[4]=4621834374587875328L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
	private static long[] mk_tokenSet_9_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=25881482936864L;
		data[2]=58547344911630848L;
		data[3]=896220723893501992L;
		data[4]=4910225279437253130L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
	private static long[] mk_tokenSet_10_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693986L;
		data[1]=-9204231600999497597L;
		data[2]=2460385145816236045L;
		data[3]=180153889289443458L;
		data[4]=4890788379506266144L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_10_ = new BitSet(mk_tokenSet_10_());
	private static long[] mk_tokenSet_11_()
	{
		long[] data = new long[10];
		data[0]=7205759403792793634L;
		data[1]=-6330451468342080599L;
		data[2]=8643828224537028237L;
		data[3]=1076471645486889150L;
		data[4]=5188041210854702074L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_11_ = new BitSet(mk_tokenSet_11_());
	private static long[] mk_tokenSet_12_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=25881482936864L;
		data[2]=202662532987486720L;
		data[3]=896220723893501992L;
		data[4]=4910225279437253130L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_12_ = new BitSet(mk_tokenSet_12_());
	private static long[] mk_tokenSet_13_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=61065871802921L;
		data[2]=562951603829735936L;
		data[3]=932250895302000680L;
		data[4]=4917543698105133578L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_13_ = new BitSet(mk_tokenSet_13_());
	private static long[] mk_tokenSet_14_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=21990232555520L;
		data[2]=549755813888L;
		data[3]=882709925011128320L;
		data[4]=4908958640968312832L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_14_ = new BitSet(mk_tokenSet_14_());
	private static long[] mk_tokenSet_15_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693986L;
		data[1]=-9223336715026956151L;
		data[2]=2676557929070870541L;
		data[3]=144115471543736450L;
		data[4]=4890657537706430496L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_15_ = new BitSet(mk_tokenSet_15_());
	private static long[] mk_tokenSet_16_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693986L;
		data[1]=-9223336715026956151L;
		data[2]=2676557927997128717L;
		data[3]=144115471543736450L;
		data[4]=4890647642034671648L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_16_ = new BitSet(mk_tokenSet_16_());
	private static long[] mk_tokenSet_17_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=21990232555520L;
		data[2]=549755813888L;
		data[3]=882709925011128320L;
		data[4]=4908938849759012864L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_17_ = new BitSet(mk_tokenSet_17_());
	private static long[] mk_tokenSet_18_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693986L;
		data[1]=-9223336715026956151L;
		data[2]=2676557929070870541L;
		data[3]=144115471543736450L;
		data[4]=4890657537169559584L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_18_ = new BitSet(mk_tokenSet_18_());
	private static long[] mk_tokenSet_19_()
	{
		long[] data = new long[10];
		data[0]=288230376151711776L;
		data[1]=576486633786360352L;
		data[2]=58547344911630848L;
		data[3]=896220723893501992L;
		data[4]=4910225279437253130L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_19_ = new BitSet(mk_tokenSet_19_());
	private static long[] mk_tokenSet_20_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=17592186044416L;
		data[2]=549755813888L;
		data[3]=864691128455135232L;
		data[4]=4611700174840922112L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_20_ = new BitSet(mk_tokenSet_20_());
	private static long[] mk_tokenSet_21_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=4398046511104L;
		data[2]=0L;
		data[3]=18018796555993088L;
		data[4]=297238674918090752L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_21_ = new BitSet(mk_tokenSet_21_());
	private static long[] mk_tokenSet_22_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=1151781389779488L;
		data[2]=58547344911630976L;
		data[3]=896220723893501996L;
		data[4]=4910225279437253194L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_22_ = new BitSet(mk_tokenSet_22_());
	private static long[] mk_tokenSet_23_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=137438953472L;
		data[2]=2306134659018539016L;
		data[3]=144115196665796736L;
		data[4]=20547673300930592L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_23_ = new BitSet(mk_tokenSet_23_());
	private static long[] mk_tokenSet_24_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=1186965778645672L;
		data[2]=573085803039687168L;
		data[3]=932250895302033454L;
		data[4]=5167493537553738250L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_24_ = new BitSet(mk_tokenSet_24_());
	private static long[] mk_tokenSet_25_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=1151781389779488L;
		data[2]=58547344911630848L;
		data[3]=896220723893501996L;
		data[4]=4910225279437253130L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_25_ = new BitSet(mk_tokenSet_25_());
	private static long[] mk_tokenSet_26_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693986L;
		data[1]=61203310756520L;
		data[2]=2879220462058226184L;
		data[3]=1076366091967830186L;
		data[4]=5188041210854668842L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_26_ = new BitSet(mk_tokenSet_26_());
	private static long[] mk_tokenSet_27_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=137438953472L;
		data[2]=2306136858041794568L;
		data[3]=144115196665796736L;
		data[4]=20547673300930592L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_27_ = new BitSet(mk_tokenSet_27_());
	private static long[] mk_tokenSet_28_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=2306282813865197824L;
		data[2]=5764608278948487168L;
		data[3]=864726313095659536L;
		data[4]=32768L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_28_ = new BitSet(mk_tokenSet_28_());
	private static long[] mk_tokenSet_29_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=-9223336715026956151L;
		data[2]=2676557927997128717L;
		data[3]=144115471543736450L;
		data[4]=278941831861112864L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_29_ = new BitSet(mk_tokenSet_29_());
	private static long[] mk_tokenSet_30_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=0L;
		data[2]=144405463440818176L;
		data[3]=8589942784L;
		data[4]=4611846547125043200L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_30_ = new BitSet(mk_tokenSet_30_());
	private static long[] mk_tokenSet_31_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=25881482936864L;
		data[2]=202662532987486720L;
		data[3]=896220723893501992L;
		data[4]=4910788229390674442L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_31_ = new BitSet(mk_tokenSet_31_());
	private static long[] mk_tokenSet_32_()
	{
		long[] data = new long[10];
		data[0]=2L;
		data[1]=0L;
		data[2]=1374439882760L;
		data[3]=4096L;
		data[4]=18295873486192672L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_32_ = new BitSet(mk_tokenSet_32_());
	private static long[] mk_tokenSet_33_()
	{
		long[] data = new long[10];
		data[0]=2L;
		data[1]=0L;
		data[2]=1374423105544L;
		data[3]=4096L;
		data[4]=18295873486192672L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_33_ = new BitSet(mk_tokenSet_33_());
	private static long[] mk_tokenSet_34_()
	{
		long[] data = new long[10];
		data[0]=2L;
		data[1]=0L;
		data[2]=1374389551112L;
		data[3]=4096L;
		data[4]=18295873486192672L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_34_ = new BitSet(mk_tokenSet_34_());
	private static long[] mk_tokenSet_35_()
	{
		long[] data = new long[10];
		data[0]=2L;
		data[1]=137438953472L;
		data[2]=2306134659018539016L;
		data[3]=8589938816L;
		data[4]=20547673300930592L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_35_ = new BitSet(mk_tokenSet_35_());
	private static long[] mk_tokenSet_36_()
	{
		long[] data = new long[10];
		data[0]=2L;
		data[1]=0L;
		data[2]=1374423105544L;
		data[3]=4096L;
		data[4]=20547673299877920L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_36_ = new BitSet(mk_tokenSet_36_());
	private static long[] mk_tokenSet_37_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=17592186044416L;
		data[2]=549755813888L;
		data[3]=864691128455135232L;
		data[4]=4611695776593084416L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_37_ = new BitSet(mk_tokenSet_37_());
	private static long[] mk_tokenSet_38_()
	{
		long[] data = new long[10];
		data[0]=32L;
		data[1]=25881482936864L;
		data[2]=58547344911630848L;
		data[3]=896220723893501992L;
		data[4]=4909099378456668682L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_38_ = new BitSet(mk_tokenSet_38_());
	private static long[] mk_tokenSet_39_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=-9223371899415822207L;
		data[2]=2316269957740380173L;
		data[3]=144115196665829506L;
		data[4]=278941831844335648L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_39_ = new BitSet(mk_tokenSet_39_());
	private static long[] mk_tokenSet_40_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=-9223371899399044983L;
		data[2]=2316269957740380173L;
		data[3]=144115196665829506L;
		data[4]=278941831844335648L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_40_ = new BitSet(mk_tokenSet_40_());
	private static long[] mk_tokenSet_41_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=17592186044416L;
		data[2]=549755813888L;
		data[3]=864691128455135232L;
		data[4]=4621834374587875328L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_41_ = new BitSet(mk_tokenSet_41_());
	private static long[] mk_tokenSet_42_()
	{
		long[] data = new long[10];
		data[0]=0L;
		data[1]=17592186044416L;
		data[2]=549755813888L;
		data[3]=864691128455135232L;
		data[4]=4612826075821506560L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_42_ = new BitSet(mk_tokenSet_42_());
	private static long[] mk_tokenSet_43_()
	{
		long[] data = new long[10];
		data[0]=2305843009213693954L;
		data[1]=-9223336715026956151L;
		data[2]=2676557927997128717L;
		data[3]=4755801489971124354L;
		data[4]=278941831861112864L;
		for (int i = 5; i<=9; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_43_ = new BitSet(mk_tokenSet_43_());
	
}
}
