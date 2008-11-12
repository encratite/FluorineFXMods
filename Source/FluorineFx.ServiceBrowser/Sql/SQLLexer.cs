// $ANTLR 2.7.6 (2005-12-22): "sql.g" -> "SQLLexer.cs"$

namespace FluorineFx.ServiceBrowser.Sql
{
	// Generate header specific to lexer CSharp file
	using System;
	using Stream                          = System.IO.Stream;
	using TextReader                      = System.IO.TextReader;
	using Hashtable                       = System.Collections.Hashtable;
	using Comparer                        = System.Collections.Comparer;
	using CaseInsensitiveHashCodeProvider = System.Collections.CaseInsensitiveHashCodeProvider;
	using CaseInsensitiveComparer         = System.Collections.CaseInsensitiveComparer;
	
	using TokenStreamException            = antlr.TokenStreamException;
	using TokenStreamIOException          = antlr.TokenStreamIOException;
	using TokenStreamRecognitionException = antlr.TokenStreamRecognitionException;
	using CharStreamException             = antlr.CharStreamException;
	using CharStreamIOException           = antlr.CharStreamIOException;
	using ANTLRException                  = antlr.ANTLRException;
	using CharScanner                     = antlr.CharScanner;
	using InputBuffer                     = antlr.InputBuffer;
	using ByteBuffer                      = antlr.ByteBuffer;
	using CharBuffer                      = antlr.CharBuffer;
	using Token                           = antlr.Token;
	using IToken                          = antlr.IToken;
	using CommonToken                     = antlr.CommonToken;
	using SemanticException               = antlr.SemanticException;
	using RecognitionException            = antlr.RecognitionException;
	using NoViableAltForCharException     = antlr.NoViableAltForCharException;
	using MismatchedCharException         = antlr.MismatchedCharException;
	using TokenStream                     = antlr.TokenStream;
	using LexerSharedInputState           = antlr.LexerSharedInputState;
	using BitSet                          = antlr.collections.impl.BitSet;
	
//  Class preamble starts here - right before the class definition in the generated class file
//#pragma warning disable 219, 162
//  Class preamble ends here

	internal 	class SQLLexer : antlr.CharScanner	, TokenStream
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
		public SQLLexer(Stream ins) : this(new ByteBuffer(ins))
		{
		}
		
		public SQLLexer(TextReader r) : this(new CharBuffer(r))
		{
		}
		
		public SQLLexer(InputBuffer ib)		 : this(new LexerSharedInputState(ib))
		{
		}
		
		public SQLLexer(LexerSharedInputState state) : base(state)
		{
			initialize();
		}
		private void initialize()
		{
			caseSensitiveLiterals = false;
			setCaseSensitive(true);
			literals = new Hashtable(100, (float) 0.4, CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
			literals.Add("absolute", 55);
			literals.Add("year", 280);
			literals.Add("month", 186);
			literals.Add("no", 192);
			literals.Add("command_function", 17);
			literals.Add("trim", 259);
			literals.Add("both", 74);
			literals.Add("first", 140);
			literals.Add("timestamp", 251);
			literals.Add("precision", 211);
			literals.Add("ada", 5);
			literals.Add("session_user", 234);
			literals.Add("system_user", 246);
			literals.Add("current_date", 103);
			literals.Add("at", 67);
			literals.Add("restrict", 223);
			literals.Add("bit_length", 73);
			literals.Add("translate", 257);
			literals.Add("is", 169);
			literals.Add("identity", 155);
			literals.Add("having", 153);
			literals.Add("using", 268);
			literals.Add("as", 64);
			literals.Add("end", 128);
			literals.Add("create", 100);
			literals.Add("nchar", 190);
			literals.Add("collation_schema", 15);
			literals.Add("domain", 124);
			literals.Add("cascaded", 77);
			literals.Add("initially", 159);
			literals.Add("bit", 72);
			literals.Add("execute", 134);
			literals.Add("primary", 214);
			literals.Add("deallocate", 110);
			literals.Add("unique", 262);
			literals.Add("diagnostics", 121);
			literals.Add("default", 114);
			literals.Add("dynamic_function", 28);
			literals.Add("int", 164);
			literals.Add("space", 239);
			literals.Add("assertion", 66);
			literals.Add("false", 138);
			literals.Add("dec", 111);
			literals.Add("check", 85);
			literals.Add("whenever", 275);
			literals.Add("convert", 97);
			literals.Add("deferred", 116);
			literals.Add("in", 157);
			literals.Add("current_user", 106);
			literals.Add("mumps", 35);
			literals.Add("are", 63);
			literals.Add("foreign", 143);
			literals.Add("left", 176);
			literals.Add("day", 109);
			literals.Add("current", 102);
			literals.Add("current_time", 104);
			literals.Add("decimal", 112);
			literals.Add("collate", 88);
			literals.Add("count", 99);
			literals.Add("prepare", 212);
			literals.Add("public", 218);
			literals.Add("rollback", 226);
			literals.Add("from", 145);
			literals.Add("continue", 96);
			literals.Add("to", 254);
			literals.Add("more", 34);
			literals.Add("message_octet_length", 32);
			literals.Add("extract", 137);
			literals.Add("any", 62);
			literals.Add("number", 38);
			literals.Add("table_name", 51);
			literals.Add("preserve", 213);
			literals.Add("substring", 244);
			literals.Add("timezone_minute", 253);
			literals.Add("sql", 240);
			literals.Add("by", 75);
			literals.Add("or", 203);
			literals.Add("hour", 154);
			literals.Add("authorization", 68);
			literals.Add("time", 250);
			literals.Add("select", 232);
			literals.Add("national", 188);
			literals.Add("nullable", 37);
			literals.Add("names", 187);
			literals.Add("serializable", 48);
			literals.Add("natural", 189);
			literals.Add("column", 90);
			literals.Add("current_timestamp", 105);
			literals.Add("escape", 130);
			literals.Add("values", 270);
			literals.Add("commit", 91);
			literals.Add("user", 267);
			literals.Add("between", 71);
			literals.Add("usage", 266);
			literals.Add("allocate", 59);
			literals.Add("alter", 60);
			literals.Add("insensitive", 162);
			literals.Add("go", 149);
			literals.Add("procedure", 217);
			literals.Add("input", 161);
			literals.Add("row_count", 45);
			literals.Add("on", 199);
			literals.Add("sqlstate", 243);
			literals.Add("pascal", 39);
			literals.Add("scale", 46);
			literals.Add("integer", 165);
			literals.Add("zone", 281);
			literals.Add("length", 30);
			literals.Add("class_origin", 11);
			literals.Add("global", 148);
			literals.Add("constraint_catalog", 21);
			literals.Add("revoke", 224);
			literals.Add("describe", 119);
			literals.Add("coalesce", 87);
			literals.Add("constraint", 94);
			literals.Add("table", 247);
			literals.Add("float", 141);
			literals.Add("not", 193);
			literals.Add("schema_name", 47);
			literals.Add("name", 36);
			literals.Add("collation", 89);
			literals.Add("cast", 79);
			literals.Add("constraint_schema", 23);
			literals.Add("smallint", 237);
			literals.Add("returned_sqlstate", 44);
			literals.Add("drop", 126);
			literals.Add("second", 230);
			literals.Add("order", 204);
			literals.Add("date", 108);
			literals.Add("isolation", 170);
			literals.Add("session", 233);
			literals.Add("numeric", 196);
			literals.Add("end-exec", 129);
			literals.Add("cursor", 107);
			literals.Add("delete", 117);
			literals.Add("open", 201);
			literals.Add("inner", 160);
			literals.Add("varying", 272);
			literals.Add("desc", 118);
			literals.Add("some", 238);
			literals.Add("temporary", 248);
			literals.Add("max", 182);
			literals.Add("references", 221);
			literals.Add("section", 231);
			literals.Add("character", 82);
			literals.Add("character_length", 84);
			literals.Add("external", 136);
			literals.Add("get", 147);
			literals.Add("of", 198);
			literals.Add("update", 264);
			literals.Add("then", 249);
			literals.Add("data", 25);
			literals.Add("lower", 180);
			literals.Add("upper", 265);
			literals.Add("nullif", 195);
			literals.Add("insert", 163);
			literals.Add("datetime_interval_precision", 27);
			literals.Add("cascade", 76);
			literals.Add("asc", 65);
			literals.Add("transaction", 256);
			literals.Add("datetime_interval_code", 26);
			literals.Add("right", 225);
			literals.Add("constraint_name", 22);
			literals.Add("collation_name", 14);
			literals.Add("message_length", 31);
			literals.Add("action", 56);
			literals.Add("constraints", 95);
			literals.Add("sqlerror", 242);
			literals.Add("exception", 132);
			literals.Add("union", 261);
			literals.Add("connect", 92);
			literals.Add("level", 177);
			literals.Add("real", 220);
			literals.Add("catalog", 80);
			literals.Add("avg", 69);
			literals.Add("rows", 227);
			literals.Add("next", 191);
			literals.Add("found", 144);
			literals.Add("join", 171);
			literals.Add("overlaps", 207);
			literals.Add("grant", 151);
			literals.Add("when", 274);
			literals.Add("server_name", 49);
			literals.Add("group", 152);
			literals.Add("where", 276);
			literals.Add("goto", 150);
			literals.Add("true", 260);
			literals.Add("char_length", 83);
			literals.Add("set", 235);
			literals.Add("close", 86);
			literals.Add("last", 174);
			literals.Add("column_name", 16);
			literals.Add("octet_length", 197);
			literals.Add("character_set_schema", 10);
			literals.Add("option", 202);
			literals.Add("c", 6);
			literals.Add("view", 273);
			literals.Add("and", 61);
			literals.Add("disconnect", 122);
			literals.Add("prior", 215);
			literals.Add("work", 278);
			literals.Add("pad", 208);
			literals.Add("leading", 175);
			literals.Add("like", 178);
			literals.Add("condition_number", 19);
			literals.Add("only", 200);
			literals.Add("pli", 40);
			literals.Add("fortran", 29);
			literals.Add("min", 183);
			literals.Add("declare", 113);
			literals.Add("immediate", 156);
			literals.Add("cursor_name", 24);
			literals.Add("for", 142);
			literals.Add("scroll", 229);
			literals.Add("case", 78);
			literals.Add("returned_length", 42);
			literals.Add("repeatable", 41);
			literals.Add("language", 173);
			literals.Add("translation", 258);
			literals.Add("into", 168);
			literals.Add("null", 194);
			literals.Add("read", 219);
			literals.Add("all", 58);
			literals.Add("sum", 245);
			literals.Add("local", 179);
			literals.Add("connection", 93);
			literals.Add("deferrable", 115);
			literals.Add("trailing", 255);
			literals.Add("cross", 101);
			literals.Add("committed", 18);
			literals.Add("exists", 135);
			literals.Add("match", 181);
			literals.Add("key", 172);
			literals.Add("double", 125);
			literals.Add("size", 236);
			literals.Add("distinct", 123);
			literals.Add("unknown", 263);
			literals.Add("character_set_name", 9);
			literals.Add("catalog_name", 7);
			literals.Add("uncommitted", 53);
			literals.Add("intersect", 166);
			literals.Add("schema", 228);
			literals.Add("except", 131);
			literals.Add("sqlcode", 241);
			literals.Add("message_text", 33);
			literals.Add("partial", 209);
			literals.Add("interval", 167);
			literals.Add("position", 210);
			literals.Add("exec", 133);
			literals.Add("descriptor", 120);
			literals.Add("char", 81);
			literals.Add("full", 146);
			literals.Add("begin", 70);
			literals.Add("timezone_hour", 252);
			literals.Add("returned_octet_length", 43);
			literals.Add("type", 52);
			literals.Add("character_set_catalog", 8);
			literals.Add("cobol", 12);
			literals.Add("indicator", 158);
			literals.Add("privileges", 216);
			literals.Add("outer", 205);
			literals.Add("unnamed", 54);
			literals.Add("collation_catalog", 13);
			literals.Add("add", 57);
			literals.Add("module", 185);
			literals.Add("write", 279);
			literals.Add("with", 277);
			literals.Add("relative", 222);
			literals.Add("value", 269);
			literals.Add("corresponding", 98);
			literals.Add("varchar", 271);
			literals.Add("output", 206);
			literals.Add("else", 127);
			literals.Add("connection_name", 20);
			literals.Add("subclass_origin", 50);
			literals.Add("fetch", 139);
			literals.Add("minute", 184);
		}
		
		override public IToken nextToken()			//throws TokenStreamException
		{
			IToken theRetToken = null;
tryAgain:
			for (;;)
			{
				IToken _token = null;
				int _ttype = Token.INVALID_TYPE;
				setCommitToPath(false);
				int _m;
				_m = mark();
				resetText();
				try     // for char stream error handling
				{
					try     // for lexical error handling
					{
						switch ( cached_LA1 )
						{
						case '.':  case '0':  case '1':  case '2':
						case '3':  case '4':  case '5':  case '6':
						case '7':  case '8':  case '9':
						{
							mEXACT_NUM_LIT(true);
							theRetToken = returnToken_;
							break;
						}
						case '\t':  case '\n':  case '\r':  case ' ':
						case '-':
						{
							mSEPARATOR(true);
							theRetToken = returnToken_;
							break;
						}
						case '\'':
						{
							mCHAR_STRING(true);
							theRetToken = returnToken_;
							break;
						}
						case '%':
						{
							mPERCENT(true);
							theRetToken = returnToken_;
							break;
						}
						case '&':
						{
							mAMPERSAND(true);
							theRetToken = returnToken_;
							break;
						}
						case '(':
						{
							mLEFT_PAREN(true);
							theRetToken = returnToken_;
							break;
						}
						case ')':
						{
							mRIGHT_PAREN(true);
							theRetToken = returnToken_;
							break;
						}
						case '*':
						{
							mASTERISK(true);
							theRetToken = returnToken_;
							break;
						}
						case '+':
						{
							mPLUS_SIGN(true);
							theRetToken = returnToken_;
							break;
						}
						case ',':
						{
							mCOMMA(true);
							theRetToken = returnToken_;
							break;
						}
						case '/':
						{
							mSOLIDUS(true);
							theRetToken = returnToken_;
							break;
						}
						case ':':
						{
							mCOLON(true);
							theRetToken = returnToken_;
							break;
						}
						case '$':
						{
							mDOLLAR_SIGN(true);
							theRetToken = returnToken_;
							break;
						}
						case ';':
						{
							mSEMICOLON(true);
							theRetToken = returnToken_;
							break;
						}
						case '<':
						{
							mLESS_THAN_OP(true);
							theRetToken = returnToken_;
							break;
						}
						case '=':
						{
							mEQUALS_OP(true);
							theRetToken = returnToken_;
							break;
						}
						case '>':
						{
							mGREATER_THAN_OP(true);
							theRetToken = returnToken_;
							break;
						}
						case '?':
						{
							mQUESTION_MARK(true);
							theRetToken = returnToken_;
							break;
						}
						case '|':
						{
							mVERTICAL_BAR(true);
							theRetToken = returnToken_;
							break;
						}
						case ']':
						{
							mRIGHT_BRACKET(true);
							theRetToken = returnToken_;
							break;
						}
						case '_':
						{
							mINTRODUCER(true);
							theRetToken = returnToken_;
							break;
						}
						default:
							if ((cached_LA1=='"'||cached_LA1=='['||cached_LA1=='`') && (tokenSet_0_.member(cached_LA2)))
							{
								mDELIMITED_ID(true);
								theRetToken = returnToken_;
							}
							else if ((tokenSet_1_.member(cached_LA1))) {
								mREGULAR_ID(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='"') && (true)) {
								mDOUBLE_QUOTE(true);
								theRetToken = returnToken_;
							}
							else if ((cached_LA1=='[') && (true)) {
								mLEFT_BRACKET(true);
								theRetToken = returnToken_;
							}
						else
						{
							if (cached_LA1==EOF_CHAR) { uponEOF(); returnToken_ = makeToken(Token.EOF_TYPE); }
									else
					{
					commit();
					try {mANY_CHAR(false);}
					catch(RecognitionException e)
					{
						// catastrophic failure
						reportError(e);
						consume();
					}
					goto tryAgain;
				}
						}
						break; }
						commit();
						if ( null==returnToken_ ) goto tryAgain; // found SKIP token
						_ttype = returnToken_.Type;
						returnToken_.Type = _ttype;
						return returnToken_;
					}
					catch (RecognitionException e) {
						if (!getCommitToPath())
						{
							rewind(_m);
							resetText();
							try {mANY_CHAR(false);}
							catch(RecognitionException ee) {
								// horrendous failure: error in filter rule
								reportError(ee);
								consume();
							}
						}
						else
							throw new TokenStreamRecognitionException(e);
					}
				}
				catch (CharStreamException cse) {
					if ( cse is CharStreamIOException ) {
						throw new TokenStreamIOException(((CharStreamIOException)cse).io);
					}
					else {
						throw new TokenStreamException(cse.Message);
					}
				}
			}
		}
		
	public void mREGULAR_ID(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = REGULAR_ID;
		
		if ((tokenSet_2_.member(cached_LA1)) && (cached_LA2=='\''))
		{
			{
				switch ( cached_LA1 )
				{
				case 'N':  case 'n':
				{
					mNATIONAL_CHAR_STRING_LIT(false);
					_ttype = NATIONAL_CHAR_STRING_LIT;
					break;
				}
				case 'B':  case 'b':
				{
					mBIT_STRING_LIT(false);
					_ttype = BIT_STRING_LIT;
					break;
				}
				case 'X':  case 'x':
				{
					mHEX_STRING_LIT(false);
					_ttype = HEX_STRING_LIT;
					break;
				}
				default:
				{
					throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
				}
				 }
			}
		}
		else if ((tokenSet_1_.member(cached_LA1)) && (true)) {
			{
				mSIMPLE_LETTER(false);
			}
			{    // ( ... )*
				for (;;)
				{
					switch ( cached_LA1 )
					{
					case '_':
					{
						match('_');
						break;
					}
					case '0':  case '1':  case '2':  case '3':
					case '4':  case '5':  case '6':  case '7':
					case '8':  case '9':
					{
						matchRange('0','9');
						break;
					}
					default:
						if ((tokenSet_1_.member(cached_LA1)))
						{
							mSIMPLE_LETTER(false);
						}
					else
					{
						goto _loop5_breakloop;
					}
					break; }
				}
_loop5_breakloop:				;
			}    // ( ... )*
			_ttype = testLiteralsTable(REGULAR_ID);
		}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mNATIONAL_CHAR_STRING_LIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = NATIONAL_CHAR_STRING_LIT;
		
		{
			switch ( cached_LA1 )
			{
			case 'N':
			{
				match('N');
				break;
			}
			case 'n':
			{
				match('n');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		{ // ( ... )+
			int _cnt35=0;
			for (;;)
			{
				if ((cached_LA1=='\''))
				{
					match('\'');
					{    // ( ... )*
						for (;;)
						{
							if ((cached_LA1=='\'') && (cached_LA2=='\''))
							{
								match('\'');
								match('\'');
							}
							else if ((tokenSet_3_.member(cached_LA1))) {
								{
									match(tokenSet_3_);
								}
							}
							else if ((cached_LA1=='\n'||cached_LA1=='\r')) {
								mNEWLINE(false);
							}
							else
							{
								goto _loop33_breakloop;
							}
							
						}
_loop33_breakloop:						;
					}    // ( ... )*
					match('\'');
					{
						if ((tokenSet_4_.member(cached_LA1)))
						{
							mSEPARATOR(false);
						}
						else {
						}
						
					}
				}
				else
				{
					if (_cnt35 >= 1) { goto _loop35_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt35++;
			}
_loop35_breakloop:			;
		}    // ( ... )+
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mBIT_STRING_LIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = BIT_STRING_LIT;
		
		{
			switch ( cached_LA1 )
			{
			case 'B':
			{
				match('B');
				break;
			}
			case 'b':
			{
				match('b');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		{ // ( ... )+
			int _cnt42=0;
			for (;;)
			{
				if ((cached_LA1=='\''))
				{
					match('\'');
					{    // ( ... )*
						for (;;)
						{
							switch ( cached_LA1 )
							{
							case '0':
							{
								match('0');
								break;
							}
							case '1':
							{
								match('1');
								break;
							}
							default:
							{
								goto _loop40_breakloop;
							}
							 }
						}
_loop40_breakloop:						;
					}    // ( ... )*
					match('\'');
					{
						if ((tokenSet_4_.member(cached_LA1)))
						{
							mSEPARATOR(false);
						}
						else {
						}
						
					}
				}
				else
				{
					if (_cnt42 >= 1) { goto _loop42_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt42++;
			}
_loop42_breakloop:			;
		}    // ( ... )+
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mHEX_STRING_LIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = HEX_STRING_LIT;
		
		{
			switch ( cached_LA1 )
			{
			case 'X':
			{
				match('X');
				break;
			}
			case 'x':
			{
				match('x');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		{ // ( ... )+
			int _cnt49=0;
			for (;;)
			{
				if ((cached_LA1=='\''))
				{
					match('\'');
					{    // ( ... )*
						for (;;)
						{
							switch ( cached_LA1 )
							{
							case 'a':  case 'b':  case 'c':  case 'd':
							case 'e':  case 'f':
							{
								matchRange('a','f');
								break;
							}
							case 'A':  case 'B':  case 'C':  case 'D':
							case 'E':  case 'F':
							{
								matchRange('A','F');
								break;
							}
							case '0':  case '1':  case '2':  case '3':
							case '4':  case '5':  case '6':  case '7':
							case '8':  case '9':
							{
								matchRange('0','9');
								break;
							}
							default:
							{
								goto _loop47_breakloop;
							}
							 }
						}
_loop47_breakloop:						;
					}    // ( ... )*
					match('\'');
					{
						if ((tokenSet_4_.member(cached_LA1)))
						{
							mSEPARATOR(false);
						}
						else {
						}
						
					}
				}
				else
				{
					if (_cnt49 >= 1) { goto _loop49_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt49++;
			}
_loop49_breakloop:			;
		}    // ( ... )+
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mSIMPLE_LETTER(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SIMPLE_LETTER;
		
		switch ( cached_LA1 )
		{
		case 'a':  case 'b':  case 'c':  case 'd':
		case 'e':  case 'f':  case 'g':  case 'h':
		case 'i':  case 'j':  case 'k':  case 'l':
		case 'm':  case 'n':  case 'o':  case 'p':
		case 'q':  case 'r':  case 's':  case 't':
		case 'u':  case 'v':  case 'w':  case 'x':
		case 'y':  case 'z':
		{
			matchRange('a','z');
			break;
		}
		case 'A':  case 'B':  case 'C':  case 'D':
		case 'E':  case 'F':  case 'G':  case 'H':
		case 'I':  case 'J':  case 'K':  case 'L':
		case 'M':  case 'N':  case 'O':  case 'P':
		case 'Q':  case 'R':  case 'S':  case 'T':
		case 'U':  case 'V':  case 'W':  case 'X':
		case 'Y':  case 'Z':
		{
			matchRange('A','Z');
			break;
		}
		default:
			if (((cached_LA1 >= '\u007f' && cached_LA1 <= '\u00ff')))
			{
				matchRange('\x7f','\xff');
			}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		break; }
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mDELIMITED_ID(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DELIMITED_ID;
		
		switch ( cached_LA1 )
		{
		case '"':
		{
			match('"');
			{ // ( ... )+
				int _cnt9=0;
				for (;;)
				{
					if ((cached_LA1=='"') && (cached_LA2=='"'))
					{
						match('"');
						match('"');
					}
					else if ((tokenSet_5_.member(cached_LA1))) {
						{
							match(tokenSet_5_);
						}
					}
					else
					{
						if (_cnt9 >= 1) { goto _loop9_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					
					_cnt9++;
				}
_loop9_breakloop:				;
			}    // ( ... )+
			match('"');
			_ttype = testLiteralsTable(DELIMITED_ID);
			break;
		}
		case '`':
		{
			match('`');
			{ // ( ... )+
				int _cnt12=0;
				for (;;)
				{
					if ((tokenSet_6_.member(cached_LA1)))
					{
						{
							match(tokenSet_6_);
						}
					}
					else
					{
						if (_cnt12 >= 1) { goto _loop12_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					
					_cnt12++;
				}
_loop12_breakloop:				;
			}    // ( ... )+
			match('`');
			_ttype = testLiteralsTable(DELIMITED_ID);
			break;
		}
		case '[':
		{
			match('[');
			{ // ( ... )+
				int _cnt15=0;
				for (;;)
				{
					if ((tokenSet_7_.member(cached_LA1)))
					{
						{
							match(tokenSet_7_);
						}
					}
					else
					{
						if (_cnt15 >= 1) { goto _loop15_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					
					_cnt15++;
				}
_loop15_breakloop:				;
			}    // ( ... )+
			match(']');
			_ttype = testLiteralsTable(DELIMITED_ID);
			break;
		}
		default:
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		 }
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mEXACT_NUM_LIT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = EXACT_NUM_LIT;
		
		if ((cached_LA1=='.') && ((cached_LA2 >= '0' && cached_LA2 <= '9')))
		{
			match('.');
			mUNSIGNED_INTEGER(false);
			{
				if ((cached_LA1=='E'||cached_LA1=='e'))
				{
					{
						switch ( cached_LA1 )
						{
						case 'E':
						{
							match('E');
							break;
						}
						case 'e':
						{
							match('e');
							break;
						}
						default:
						{
							throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
						}
						 }
					}
					{
						switch ( cached_LA1 )
						{
						case '+':
						{
							match('+');
							break;
						}
						case '-':
						{
							match('-');
							break;
						}
						case '0':  case '1':  case '2':  case '3':
						case '4':  case '5':  case '6':  case '7':
						case '8':  case '9':
						{
							break;
						}
						default:
						{
							throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
						}
						 }
					}
					mUNSIGNED_INTEGER(false);
					_ttype = APPROXIMATE_NUM_LIT;
				}
				else {
				}
				
			}
		}
		else if ((cached_LA1=='.') && (cached_LA2=='.')) {
			match('.');
			match('.');
			_ttype = DOUBLE_PERIOD;
		}
		else if (((cached_LA1 >= '0' && cached_LA1 <= '9'))) {
			mUNSIGNED_INTEGER(false);
			{
				if ((cached_LA1=='.'))
				{
					match('.');
					{
						if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
						{
							mUNSIGNED_INTEGER(false);
						}
						else {
						}
						
					}
				}
				else {
					_ttype = UNSIGNED_INTEGER;
				}
				
			}
			{
				if ((cached_LA1=='E'||cached_LA1=='e'))
				{
					{
						switch ( cached_LA1 )
						{
						case 'E':
						{
							match('E');
							break;
						}
						case 'e':
						{
							match('e');
							break;
						}
						default:
						{
							throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
						}
						 }
					}
					{
						switch ( cached_LA1 )
						{
						case '+':
						{
							match('+');
							break;
						}
						case '-':
						{
							match('-');
							break;
						}
						case '0':  case '1':  case '2':  case '3':
						case '4':  case '5':  case '6':  case '7':
						case '8':  case '9':
						{
							break;
						}
						default:
						{
							throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
						}
						 }
					}
					mUNSIGNED_INTEGER(false);
					_ttype = APPROXIMATE_NUM_LIT;
				}
				else {
				}
				
			}
		}
		else if ((cached_LA1=='.') && (true)) {
			match('.');
			_ttype = PERIOD;
		}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mUNSIGNED_INTEGER(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = UNSIGNED_INTEGER;
		
		{ // ( ... )+
			int _cnt27=0;
			for (;;)
			{
				if (((cached_LA1 >= '0' && cached_LA1 <= '9')))
				{
					matchRange('0','9');
				}
				else
				{
					if (_cnt27 >= 1) { goto _loop27_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
				}
				
				_cnt27++;
			}
_loop27_breakloop:			;
		}    // ( ... )+
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mNEWLINE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = NEWLINE;
		
		{
			switch ( cached_LA1 )
			{
			case '\r':
			{
				match('\r');
				{
					if ((cached_LA1=='\n') && (true))
					{
						match('\n');
					}
					else {
					}
					
				}
				break;
			}
			case '\n':
			{
				match('\n');
				break;
			}
			default:
			{
				throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
			}
			 }
		}
		newline();
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSEPARATOR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SEPARATOR;
		
		if ((cached_LA1=='-') && (cached_LA2=='-'))
		{
			mCOMMENT(false);
			_ttype = Token.SKIP;
		}
		else if ((cached_LA1=='-') && (true)) {
			match('-');
			_ttype = MINUS_SIGN;
		}
		else if ((tokenSet_8_.member(cached_LA1))) {
			{ // ( ... )+
				int _cnt86=0;
				for (;;)
				{
					switch ( cached_LA1 )
					{
					case '\t':  case ' ':
					{
						mSPACE(false);
						break;
					}
					case '\n':  case '\r':
					{
						mNEWLINE(false);
						break;
					}
					default:
					{
						if (_cnt86 >= 1) { goto _loop86_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					break; }
					_cnt86++;
				}
_loop86_breakloop:				;
			}    // ( ... )+
			_ttype = Token.SKIP;
		}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCHAR_STRING(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = CHAR_STRING;
		
		if ((cached_LA1=='\'') && ((cached_LA2 >= '\u0000' && cached_LA2 <= '\u00ff')))
		{
			{ // ( ... )+
				int _cnt56=0;
				for (;;)
				{
					if ((cached_LA1=='\''))
					{
						match('\'');
						{    // ( ... )*
							for (;;)
							{
								if ((cached_LA1=='\'') && (cached_LA2=='\''))
								{
									match('\'');
									match('\'');
								}
								else if ((tokenSet_3_.member(cached_LA1))) {
									{
										match(tokenSet_3_);
									}
								}
								else if ((cached_LA1=='\n'||cached_LA1=='\r')) {
									mNEWLINE(false);
								}
								else
								{
									goto _loop54_breakloop;
								}
								
							}
_loop54_breakloop:							;
						}    // ( ... )*
						match('\'');
						{
							if ((tokenSet_4_.member(cached_LA1)))
							{
								mSEPARATOR(false);
							}
							else {
							}
							
						}
					}
					else
					{
						if (_cnt56 >= 1) { goto _loop56_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					
					_cnt56++;
				}
_loop56_breakloop:				;
			}    // ( ... )+
		}
		else if ((cached_LA1=='\'') && (true)) {
			match('\'');
			_ttype = QUOTE;
		}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mDOUBLE_QUOTE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DOUBLE_QUOTE;
		
		match('"');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPERCENT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PERCENT;
		
		match('%');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mAMPERSAND(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = AMPERSAND;
		
		match('&');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLEFT_PAREN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LEFT_PAREN;
		
		match('(');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRIGHT_PAREN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RIGHT_PAREN;
		
		match(')');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mASTERISK(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = ASTERISK;
		
		match('*');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mPLUS_SIGN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = PLUS_SIGN;
		
		match('+');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCOMMA(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COMMA;
		
		match(',');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSOLIDUS(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SOLIDUS;
		
		match('/');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mCOLON(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COLON;
		
		if ((cached_LA1==':') && (tokenSet_9_.member(cached_LA2)))
		{
			match(':');
			{ // ( ... )+
				int _cnt68=0;
				for (;;)
				{
					switch ( cached_LA1 )
					{
					case '0':  case '1':  case '2':  case '3':
					case '4':  case '5':  case '6':  case '7':
					case '8':  case '9':
					{
						matchRange('0','9');
						break;
					}
					case '.':
					{
						match('.');
						break;
					}
					case '_':
					{
						match('_');
						break;
					}
					case '#':
					{
						match('#');
						break;
					}
					case '$':
					{
						match('$');
						break;
					}
					case '&':
					{
						match('&');
						break;
					}
					case '%':
					{
						match('%');
						break;
					}
					case '@':
					{
						match('@');
						break;
					}
					default:
						if ((tokenSet_1_.member(cached_LA1)))
						{
							mSIMPLE_LETTER(false);
						}
					else
					{
						if (_cnt68 >= 1) { goto _loop68_breakloop; } else { throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());; }
					}
					break; }
					_cnt68++;
				}
_loop68_breakloop:				;
			}    // ( ... )+
			_ttype = EMBDD_VARIABLE_NAME;
		}
		else if ((cached_LA1==':') && (true)) {
			match(':');
		}
		else
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mDOLLAR_SIGN(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = DOLLAR_SIGN;
		
		match('$');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mSEMICOLON(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SEMICOLON;
		
		match(';');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLESS_THAN_OP(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LESS_THAN_OP;
		
		match('<');
		{
			switch ( cached_LA1 )
			{
			case '>':
			{
				match('>');
				_ttype = NOT_EQUALS_OP;
				break;
			}
			case '=':
			{
				match('=');
				_ttype = LESS_THAN_OR_EQUALS_OP;
				break;
			}
			default:
				{
				}
			break; }
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mEQUALS_OP(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = EQUALS_OP;
		
		match('=');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mGREATER_THAN_OP(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = GREATER_THAN_OP;
		
		match('>');
		{
			if ((cached_LA1=='='))
			{
				match('=');
				_ttype = GREATER_THAN_OR_EQUALS_OP;
			}
			else {
			}
			
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mQUESTION_MARK(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = QUESTION_MARK;
		
		match('?');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mVERTICAL_BAR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = VERTICAL_BAR;
		
		match('|');
		{
			if ((cached_LA1=='|'))
			{
				match('|');
				_ttype = CONCATENATION_OP;
			}
			else {
			}
			
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mLEFT_BRACKET(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = LEFT_BRACKET;
		
		match('[');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mRIGHT_BRACKET(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = RIGHT_BRACKET;
		
		match(']');
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	public void mINTRODUCER(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = INTRODUCER;
		
		match('_');
		{
			if ((tokenSet_4_.member(cached_LA1)))
			{
				mSEPARATOR(false);
				_ttype = UNDERSCORE;
			}
			else {
			}
			
		}
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mCOMMENT(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = COMMENT;
		
		match('-');
		match('-');
		{    // ( ... )*
			for (;;)
			{
				if ((tokenSet_0_.member(cached_LA1)))
				{
					{
						match(tokenSet_0_);
					}
				}
				else
				{
					goto _loop90_breakloop;
				}
				
			}
_loop90_breakloop:			;
		}    // ( ... )*
		mNEWLINE(false);
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mSPACE(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = SPACE;
		
		switch ( cached_LA1 )
		{
		case ' ':
		{
			match(' ');
			break;
		}
		case '\t':
		{
			match('\t');
			break;
		}
		default:
		{
			throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
		}
		 }
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	protected void mANY_CHAR(bool _createToken) //throws RecognitionException, CharStreamException, TokenStreamException
{
		int _ttype; IToken _token=null; int _begin=text.Length;
		_ttype = ANY_CHAR;
		
		matchNot(EOF/*_CHAR*/);
		if (_createToken && (null == _token) && (_ttype != Token.SKIP))
		{
			_token = makeToken(_ttype);
			_token.setText(text.ToString(_begin, text.Length-_begin));
		}
		returnToken_ = _token;
	}
	
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = new long[8];
		data[0]=-9217L;
		for (int i = 1; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = new long[8];
		data[0]=0L;
		data[1]=-8646911293007069186L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = { 0L, 72127979978768388L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = new long[8];
		data[0]=-549755823105L;
		for (int i = 1; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = { 35188667065856L, 0L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = new long[8];
		data[0]=-17179878401L;
		for (int i = 1; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = new long[8];
		data[0]=-17179878401L;
		data[1]=-4294967297L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	private static long[] mk_tokenSet_7_()
	{
		long[] data = new long[8];
		data[0]=-9217L;
		data[1]=-671088641L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
	private static long[] mk_tokenSet_8_()
	{
		long[] data = { 4294977024L, 0L, 0L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
	private static long[] mk_tokenSet_9_()
	{
		long[] data = new long[8];
		data[0]=288019785315254272L;
		data[1]=-8646911290859585537L;
		for (int i = 2; i<=3; i++) { data[i]=-1L; }
		for (int i = 4; i<=7; i++) { data[i]=0L; }
		return data;
	}
	public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
	
}
}
