(function (opts_) {/*

 Copyright The Closure Library Authors.
 SPDX-License-Identifier: Apache-2.0
*/
    var g = this || self, k = function (a, b) { function d() { } d.prototype = b.prototype; a.l = b.prototype; a.prototype = new d; a.prototype.constructor = a; a.j = function (e, c, f) { for (var h = Array(arguments.length - 2), q = 2; q < arguments.length; q++)h[q - 2] = arguments[q]; return b.prototype[c].apply(e, h) } }, l = function (a) { return a }; function m(a) { if (Error.captureStackTrace) Error.captureStackTrace(this, m); else { var b = Error().stack; b && (this.stack = b) } a && (this.message = String(a)) } k(m, Error); m.prototype.name = "CustomError"; var n = function (a, b) { a = a.split("%s"); for (var d = "", e = a.length - 1, c = 0; c < e; c++)d += a[c] + (c < b.length ? b[c] : "%s"); m.call(this, d + a[e]) }; k(n, m); n.prototype.name = "AssertionError"; var p = function (a, b, d) { if (!a) { var e = "Assertion failed"; if (b) { e += ": " + b; var c = Array.prototype.slice.call(arguments, 2) } throw new n("" + e, c || []); } }, r = function (a, b) { throw new n("Failure" + (a ? ": " + a : ""), Array.prototype.slice.call(arguments, 1)); }; var t; var w = function (a, b) { this.h = a === u && b || ""; this.i = v }; w.prototype.toString = function () { return "Const{" + this.h + "}" }; var x = function (a) { if (a instanceof w && a.constructor === w && a.i === v) return a.h; r("expected object of type Const, got '" + a + "'"); return "type_error:Const" }, v = {}, u = {}; var z = function (a, b) { this.g = b === y ? a : "" }; z.prototype.toString = function () { return this.g + "" };
    var A = function (a) { if (a instanceof z && a.constructor === z) return a.g; var b = typeof a; r("expected object of type TrustedResourceUrl, got '" + a + "' of type " + ("object" != b ? b : a ? Array.isArray(a) ? "array" : b : "null")); return "type_error:TrustedResourceUrl" }, E = function (a, b) {
        var d = x(a); if (!B.test(d)) throw Error("Invalid TrustedResourceUrl format: " + d); a = d.replace(C, function (e, c) {
            if (!Object.prototype.hasOwnProperty.call(b, c)) throw Error('Found marker, "' + c + '", in format string, "' + d + '", but no valid label mapping found in args: ' +
                JSON.stringify(b)); e = b[c]; return e instanceof w ? x(e) : encodeURIComponent(String(e))
        }); return D(a)
    }, C = /%{(\w+)}/g, B = /^((https:)?\/\/[0-9a-z.:[\]-]+\/|\/[^/\\]|[^:/\\%]+\/|[^:/\\%]*[?#]|about:blank#)/i, F = /^([^?#]*)(\?[^#]*)?(#[\s\S]*)?/, J = function (a) { var b = G; a = E(H, a); a = A(a).toString(); a = F.exec(a); var d = a[3] || ""; return D(a[1] + I("?", a[2] || "", b) + I("#", d, void 0)) }, y = {}, D = function (a) {
        if (void 0 === t) {
            var b = null; var d = g.trustedTypes; if (d && d.createPolicy) try {
                b = d.createPolicy("goog#html", {
                    createHTML: l, createScript: l,
                    createScriptURL: l
                })
            } catch (e) { g.console && g.console.error(e.message) } t = b
        } a = (b = t) ? b.createScriptURL(a) : a; return new z(a, y)
        }, I = function (a, b, d) { if (null == d) return b; if ("string" === typeof d) return d ? a + encodeURIComponent(d) : ""; for (var e in d) if (Object.prototype.hasOwnProperty.call(d, e)) { var c = d[e]; c = Array.isArray(c) ? c : [c]; for (var f = 0; f < c.length; f++) { var h = c[f]; null != h && (b || (b = a), b += (b.length > a.length ? "&" : "") + encodeURIComponent(e) + "=" + encodeURIComponent(String(h))) } } return b }; var aa = /^[\w+/_-]+[=]{0,2}$/; var ba = new w(u, "https://www.google.com/cse/static/style/look/%{versionDir}%{versionSlash}%{theme}.css"), K = new w(u, "https://www.google.com/cse/static/element/%{versionDir}%{versionSlash}default%{experiment}+%{lang}.css"), H = new w(u, "/js/google_cse.js"), L = new w(u, "/"); window.__gcse = window.__gcse || {}; window.__gcse.ct = Date.now();
    window.__gcse.scb = function () { var a = window.__gcse; M() || delete opts_.rawCss; var b = ca(a.initializationCallback || a.callback); google.search.cse.element.init(opts_) && ("explicit" !== a.parsetags ? "complete" === document.readyState || "interactive" === document.readyState ? (google.search.cse.element.go(), b && b()) : google.setOnLoadCallback(function () { google.search.cse.element.go(); b && b() }, !0) : b && b()) }; function ca(a) { return "function" === typeof a ? a : "string" === typeof a && "function" === typeof window[a] ? window[a] : null }
    function M() { return !(window.__gcse && window.__gcse.plainStyle) }
    function N(a) {
        var b = document.createElement("link"); b.type = "text/css"; a: { try { var d = b && b.ownerDocument, e = d && (d.defaultView || d.parentWindow); e = e || g; if (e.Element && e.Location) { var c = e; break a } } catch (h) { } c = null } if (c && "undefined" != typeof c.HTMLLinkElement && (!b || !(b instanceof c.HTMLLinkElement) && (b instanceof c.Location || b instanceof c.Element))) {
            c = typeof b; if ("object" == c && null != b || "function" == c) try { var f = b.constructor.displayName || b.constructor.name || Object.prototype.toString.call(b) } catch (h) { f = "<object could not be stringified>" } else f =
                void 0 === b ? "undefined" : null === b ? "null" : typeof b; r("Argument is not a %s (or a non-Element, non-Location mock); got: %s", "HTMLLinkElement", f)
        } b.rel = "stylesheet"; p(a instanceof z, 'URL must be TrustedResourceUrl because "rel" contains "stylesheet"'); b.href = A(a).toString(); a: { a = (b.ownerDocument && b.ownerDocument.defaultView || g).document; if (a.querySelector && (a = a.querySelector('style[nonce],link[rel="stylesheet"][nonce]')) && (a = a.nonce || a.getAttribute("nonce")) && aa.test(a)) break a; a = "" } a && b.setAttribute("nonce",
            a); return b
    }; var O, G = opts_.usqp ? { usqp: opts_.usqp } : {}, P = opts_.language.toLowerCase(); O = opts_.cselibVersion ? J({ versionDir: opts_.cselibVersion, versionSlash: L, lang: P }) : J({ versionDir: "", versionSlash: "", lang: P }); var Q = window.__gcse.scb, R = document.createElement("script"); R.src = A(O); var S, T, U = (R.ownerDocument && R.ownerDocument.defaultView || window).document, V = null === (T = U.querySelector) || void 0 === T ? void 0 : T.call(U, "script[nonce]"); (S = V ? V.nonce || V.getAttribute("nonce") || "" : "") && R.setAttribute("nonce", S); R.type = "text/javascript";
    Q && (R.onload = Q); document.getElementsByTagName("head")[0].appendChild(R); if (M()) { document.getElementsByTagName("head")[0].appendChild(N(opts_.cselibVersion ? E(K, { versionDir: opts_.cselibVersion, versionSlash: L, experiment: "", lang: opts_.language }) : E(K, { versionDir: "", versionSlash: "", experiment: "", lang: opts_.language }))); var W, X = opts_.uiOptions.cssThemeVersion || 2, Y = opts_.theme.toLowerCase(), Z = X ? "v" + X : Y.match(/v2_/g) ? "v2" : "", da = Y.replace("v2_", ""); W = E(ba, { versionDir: Z, versionSlash: Z ? L : "", theme: da }); document.getElementsByTagName("head")[0].appendChild(N(W)) };
})({
    "cx": "160e826a9c5ebe821",
    "language": "en",
    "theme": "V2_DEFAULT",
    "uiOptions": {
        "resultsUrl": "",
        "enableAutoComplete": true,
        "enableImageSearch": true,
        "imageSearchLayout": "popup",
        "resultSetSize": "filtered_cse",
        "enableOrderBy": false,
        "orderByOptions": [],
        "overlayResults": false,
        "noResultsString": "Üzgünüz hiç sonuç bulunamadı!",
        "webSearchResultSetSize": 10,
        "webSearchExtendedRestricts": {
            "filter": 0
        },
        "imageSearchExtendedRestricts": {
            "filter": 1
        },
        "imageSearchResultSetSize": 20,
        "linkTarget": "-",
        "webSearchQueryAddition": "",
        "queryParameterName": "i",
        "enableHistory": false,
        "numTopRefinements": 2147483647,
        "hideElementBranding": true,
        "cssThemeVersion": 4,
        "isSafeSearchActive": false
    },
    "protocol": "https",
    "rawCss": ".gsc-control-cse{font-family:verdana, arial, sans-serif}.gsc-control-cse .gsc-table-result{font-family:verdana, arial, sans-serif}.gsc-refinementsGradient{background:linear-gradient(to left,rgba(255,255,255,1),rgba(255,255,255,0))}.gsc-control-cse{border-color:#1A1A2E;background-color:#1A1A2E}input.gsc-input,.gsc-input-box,.gsc-input-box-hover,.gsc-input-box-focus{border-color:#DFE1E5}.gsc-search-button-v2,.gsc-search-button-v2:hover,.gsc-search-button-v2:focus{border-color:#3079ED;background-color:#4D90FE;background-image:none;filter:none}.gsc-search-button-v2 svg{fill:#FFFFFF}.gsc-tabHeader.gsc-tabhActive,.gsc-refinementHeader.gsc-refinementhActive{color:#1A73E8;border-color:#1A73E8;background-color:#FFFFFF}.gsc-tabHeader.gsc-tabhInactive,.gsc-refinementHeader.gsc-refinementhInactive{color:#666666;border-color:#666666;background-color:#FFFFFF}.gsc-webResult.gsc-result,.gsc-results .gsc-imageResult{border-color:#1A1A2E;background-color:#1A1A2E}.gsc-webResult.gsc-result:hover{border-color:#1A1A2E;background-color:#1A1A2E}.gs-webResult.gs-result a.gs-title:link,.gs-webResult.gs-result a.gs-title:link b,.gs-imageResult a.gs-title:link,.gs-imageResult a.gs-title:link b{color:#1155CC}.gs-webResult.gs-result a.gs-title:visited,.gs-webResult.gs-result a.gs-title:visited b,.gs-imageResult a.gs-title:visited,.gs-imageResult a.gs-title:visited b{color:#1155CC}.gs-webResult.gs-result a.gs-title:hover,.gs-webResult.gs-result a.gs-title:hover b,.gs-imageResult a.gs-title:hover,.gs-imageResult a.gs-title:hover b{color:#1155CC}.gs-webResult.gs-result a.gs-title:active,.gs-webResult.gs-result a.gs-title:active b,.gs-imageResult a.gs-title:active,.gs-imageResult a.gs-title:active b{color:#1155CC}.gsc-cursor-page{color:#1155CC}a.gsc-trailing-more-results:link{color:#1155CC}.gs-webResult:not(.gs-no-results-result):not(.gs-error-result) .gs-snippet,.gs-fileFormatType{color:#FFFFFF}.gs-webResult div.gs-visibleUrl{color:#6AA84F}.gs-webResult div.gs-visibleUrl-short{color:#6AA84F}.gs-webResult div.gs-visibleUrl-short{display:none}.gs-webResult div.gs-visibleUrl-long{display:block}.gs-webResult div.gs-visibleUrl-breadcrumb{display:none}.gs-promotion div.gs-visibleUrl-short{display:none}.gs-promotion div.gs-visibleUrl-long{display:block}.gs-promotion div.gs-visibleUrl-breadcrumb{display:none}.gsc-cursor-box{border-color:#1A1A2E}.gsc-results .gsc-cursor-box .gsc-cursor-page{border-color:#666666;background-color:#FFFFFF;color:#666666}.gsc-results .gsc-cursor-box .gsc-cursor-current-page{border-color:#1A73E8;background-color:#FFFFFF;color:#1A73E8}.gsc-webResult.gsc-result.gsc-promotion{border-color:#FFFFFF;background-color:#F6F6F6}.gsc-completion-title{color:#1155CC}.gsc-completion-snippet{color:#FFFFFF}.gs-promotion a.gs-title:link,.gs-promotion a.gs-title:link *,.gs-promotion .gs-snippet a:link{color:#1155CC}.gs-promotion a.gs-title:visited,.gs-promotion a.gs-title:visited *,.gs-promotion .gs-snippet a:visited{color:#1155CC}.gs-promotion a.gs-title:hover,.gs-promotion a.gs-title:hover *,.gs-promotion .gs-snippet a:hover{color:#1155CC}.gs-promotion a.gs-title:active,.gs-promotion a.gs-title:active *,.gs-promotion .gs-snippet a:active{color:#1155CC}.gs-promotion .gs-snippet,.gs-promotion .gs-title .gs-promotion-title-right,.gs-promotion .gs-title .gs-promotion-title-right *{color:#333333}.gs-promotion .gs-visibleUrl,.gs-promotion .gs-visibleUrl-short{color:#009933}.gcsc-find-more-on-google{color:#1155CC}.gcsc-find-more-on-google-magnifier{fill:#1155CC}",
    "cse_token": "AJvRUv0Em0deIXZQZtow9vOJyqHU:1652959598916",
    "isHostedPage": false,
    "exp": ["csqr", "cc"],
    "cselibVersion": "3e1664f444e6eb06",
    "usqp": "CAI\u003d"
});