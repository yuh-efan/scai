var XCookie = 
{
 escFunc:encodeURIComponent || escape, unescFunc:decodeURIComponent || unescape,
 read:function(cookieName)
 {
  var cValue="";
  if( typeof document.cookie != 'undefined' )
   cValue = ( cValue = document.cookie.match(  "(^|;)\\s*"+this.escFunc(cookieName)+'=([^;]+);?') ) ? cValue[ 2 ] : "" ;
  return this.unescFunc( cValue );
 },
 set:function( cName, cValue, cLifetime, path, domain, secure )
 {
  var duration, useSeconds = false, cs = "", expDate = new Date(),bDate=cLifetime&&cLifetime.constructor===Date?true:false;
  if( typeof path != 'string' || !/\S/.test( path ) )
   path = '';
  if( typeof cLifetime == 'string' && (duration = cLifetime.match(/^\s*secs\s*\=\s*(\d+)\s*$/i)) )
  {
   duration = Number( duration[ 1 ] );
   useSeconds = true;
  }
  else if(!bDate)
   duration = Number( cLifetime );
  if( typeof duration != 'number' && !bDate)
   alert( "Error: Duration value set incorrectly for cookie '" + cName + "'" );
  else
   if( /[\;\=]/.test( cName ) )
    alert("Illegal character in cookie name");
   else
   {
	if(bDate)
		expDate=cLifetime;
    else if( !useSeconds )
     expDate.setDate( expDate.getDate() + duration );
    else
     expDate.setSeconds( expDate.getSeconds() + duration );
    cs = this.escFunc( cName ) + "=" + this.escFunc( cValue ) + ';' ;
    if( path )
     cs += ';path=' + path;
    if( duration || bDate )
     cs += ";expires=" + expDate.toUTCString();
    if( domain )
     cs += ';domain=' + domain;
    if(secure === true)
     cs += ';secure' ;
    window.document.cookie = cs;
   }
  return this.read( cName );
 },
 refresh:function( cName, duration, path, domain, secure )
 {
  var val = this.read( cName );
  if(val !== "")
   this.set( cName, val, duration, path, domain, secure );
  return this.read( cName );
 },
 clear:function( cName, path, domain )
 {
  return !this.set( cName, 0, -1, path, domain );
 },
 clearAll:function( path )
 {
  var rslt, rxp = /(^|;)\s*([^=]+)=[^;]*/g, cString, count=0;
  if( typeof( cString = window.document.cookie ) == 'string' )
   while( ( rslt = rxp.exec( cString ) ) )
    count += ( this.set( this.unescFunc( rslt[ 2 ] ), 0, -1, path ) === "" ) ? 1 : 0;
  return count;
 },
 bump:function( cName, increment, duration, path, domain, secure )
 {
  var v;
  return this.set( cName, !isNaN( v = parseFloat( this.read( cName ), 10) ) ? v + increment : increment, duration, path, domain, secure );  
 },
 exists:function( cName )
 {
  return( Boolean( typeof document.cookie == 'string' && document.cookie.match( '(^|;)\\s*' + cName + '=' ) ) );
 },
 enabled:function()
 {
  var rv = false, cString;
  if( typeof document.cookie != 'undefined' )
  {
   for( var i = 0; this.exists( "XCookieSupport" + i ); i++ )
   ;
   rv = !!this.set( cString = "XCookieSupport" + i, 'OK', 1 );
   this.clear( cString );
  }
  return rv;
 }
};