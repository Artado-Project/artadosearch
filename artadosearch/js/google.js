(function (opts_) {/*

 Copyright The Closure Library Authors.
 SPDX-License-Identifier: Apache-2.0
*/
    'use strict';

    var f = this || self;

    function g(a) {
        return a;
    }

    var h;

    function k(a, b) {
        this.h = a === l && b || "";
        this.g = m;
    }

    function n(a) {
        return a instanceof k && a.constructor === k && a.g === m ? a.h : "type_error:Const";
    }

    var m = {},
        l = {};

    function p(a, b) {
        this.h = b === q ? a : "";
    }

    p.prototype.toString = function () {
        return this.h + "";
    };

    function r(a) {
        return a instanceof p && a.constructor === p ? a.h : "type_error:TrustedResourceUrl";
    }

    function u(a, b) {
        var c = n(a);
        if (!v.test(c)) throw Error("Invalid TrustedResourceUrl format: " + c);
        a = c.replace(w, function (d, e) {
            if (!Object.prototype.hasOwnProperty.call(b, e)) throw Error('Found marker, "' + e + '", in format string, "' + c + '", but no valid label mapping found in args: ' + JSON.stringify(b));
            d = b[e];
            return d instanceof k ? n(d) : encodeURIComponent(String(d));
        });
        return x(a);
    }

    var w = /%{(\w+)}/g,
        v = RegExp("^((https:)?//[0-9a-z.:[\\]-]+/|/[^/\\\\]|[^:/\\\\%]+/|[^:/\\\\%]*[?#]|about:blank#)", "i"),
        y = /^([^?#]*)(\?[^#]*)?(#[\s\S]*)?/;

    function z(a) {
        var b = A;
        a = u(B, a);
        a = y.exec(r(a).toString());
        var c = a[3] || "";
        return x(a[1] + C("?", a[2] || "", b) + C("#", c));
    }

    var q = {};

    function x(a) {
        if (void 0 === h) {
            var b = null;
            var c = f.trustedTypes;

            if (c && c.createPolicy) {
                try {
                    b = c.createPolicy("goog#html", {
                        createHTML: g,
                        createScript: g,
                        createScriptURL: g
                    });
                } catch (d) {
                    f.console && f.console.error(d.message);
                }
            }

            h = b;
        }

        a = (b = h) ? b.createScriptURL(a) : a;
        return new p(a, q);
    }

    function C(a, b, c) {
        if (null == c) return b;
        if ("string" === typeof c) return c ? a + encodeURIComponent(c) : "";
        for (var d in c) if (Object.prototype.hasOwnProperty.call(c, d)) {
            var e = c[d];
            e = Array.isArray(e) ? e : [e];

            for (var t = 0; t < e.length; t++) {
                var D = e[t];
                null != D && (b || (b = a), b += (b.length > a.length ? "&" : "") + encodeURIComponent(d) + "=" + encodeURIComponent(String(D)));
            }
        }
        return b;
    }

    function E(a, b) {
        this.g = b === F ? a : "";
    }

    E.prototype.toString = function () {
        return this.g.toString();
    };

    var F = {};

    /*
    
     SPDX-License-Identifier: Apache-2.0
    */
    var G;

    try {
        new URL("s://g"), G = !0;
    } catch (a) {
        G = !1;
    }

    var H = G;

    var I = "alternate author bookmark canonical cite help icon license next prefetch dns-prefetch prerender preconnect preload prev search subresource".split(" ");

    var J = new k(l, "https://www.google.com/cse/static/style/look/%{versionDir}%{versionSlash}%{theme}.css"),
        K = new k(l, "https://www.google.com/cse/static/element/%{versionDir}%{versionSlash}default%{experiment}+%{lang}.css"),
        B = new k(l, "/js/google_api.js"),
        L = new k(l, "/");

    window.__gcse = window.__gcse || {};
    window.__gcse.ct = Date.now();

    window.__gcse.scb = function () {
        var a = window.__gcse;
        M() || delete opts_.rawCss;
        var b = N(a.initializationCallback || a.callback);

        if (google.search.cse.element.init(opts_)) {
            if ("explicit" !== a.parsetags) {
                if ("complete" === document.readyState || "interactive" === document.readyState) {
                    google.search.cse.element.go();
                    null == b || b();
                } else {
                    google.setOnLoadCallback(function () {
                        google.search.cse.element.go();
                        null == b || b();
                    }, !0);
                }
            } else {
                null == b || b();
            }
        }
    };

    function N(a) {
        if ("function" === typeof a) return a;
        if ("string" !== typeof a) return null;
        a = window[a];
        return "function" !== typeof a ? null : a;
    }

    function M() {
        var a;
        return !(null == (a = window.__gcse) ? 0 : a.plainStyle);
    }

    function O(a) {
        var b = document.createElement("link"); b.type = "text/css"; a: {
            if (a instanceof p) b.href = r(a).toString(); else {
                if (-1 === I.indexOf("stylesheet")) throw Error('TrustedResourceUrl href attribute required with rel="stylesheet"'); if (a instanceof E) a = a instanceof E && a.constructor === E ? a.g : "type_error:SafeUrl"; else {
                    c: if (H) { try { var c = new URL(a) } catch (d) { c = "https:"; break c } c = c.protocol } else d: {
                        c = document.createElement("a"); try { c.href = a } catch (d) { c = void 0; break d } c = c.protocol; c = ":" === c || "" === c ? "https:" :
                            c
                    } a = "javascript:" !== c ? a : void 0
                } if (void 0 === a) break a; b.href = a
            } b.rel = "stylesheet"
        } return b
    };

    var P,
        A = opts_.usqp ? {
            usqp: opts_.usqp
        } : {},
        Q = opts_.language.toLowerCase();
    P = opts_.cselibVersion ? z({
        versionDir: opts_.cselibVersion,
        versionSlash: L,
        lang: Q
    }) : z({
        versionDir: "",
        versionSlash: "",
        lang: Q
    });
    var R = window.__gcse.scb,
        S = document.createElement("script");

    S.src = r(P);

    var T,
        U,
        V,
        W = null == (V = null == (U = (S.ownerDocument && S.ownerDocument.defaultView || window).document) ? void 0 : U.querySelector) ? void 0 : V.call(U, "script[nonce]");

    T = W ? W.nonce || W.getAttribute("nonce") || "" : "";

    T && S.setAttribute("nonce", T);

    S.type = "text/javascript";

    R && (S.onload = R);

    document.getElementsByTagName("head")[0].appendChild(S);

    if (M()) {
        document.getElementsByTagName("head")[0].appendChild(O(opts_.cselibVersion ? u(K, {
            versionDir: opts_.cselibVersion,
            versionSlash: L,
            experiment: opts_.uiOptions.cssThemeVersion && 4 !== opts_.uiOptions.cssThemeVersion ? "_v" + opts_.uiOptions.cssThemeVersion : "",
            lang: opts_.language
        }) : u(K, {
            versionDir: "",
            versionSlash: "",
            experiment: "",
            lang: opts_.language
        })));

        var X,
            Y = "v" + (opts_.uiOptions.cssThemeVersion || 4);

        X = u(J, {
            versionDir: Y,
            versionSlash: Y ? L : "",
            theme: opts_.theme.toLowerCase().replace("v2_", "")
        });

        document.getElementsByTagName("head")[0].appendChild(O(X));
    }

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
        "isSafeSearchActive": false,
        "numTopAds": 3
    },
    "protocol": "https",
    "rawCss": ".gsc-control-cse{font-family:verdana, arial, sans-serif}.gsc-control-cse .gsc-table-result{font-family:verdana, arial, sans-serif}.gsc-refinementsGradient{background:linear-gradient(to left,rgba(255,255,255,1),rgba(255,255,255,0))}.gsc-control-cse{border-color:#1A1A2E;background-color:#1A1A2E}input.gsc-input,.gsc-input-box,.gsc-input-box-hover,.gsc-input-box-focus{border-color:#DFE1E5}.gsc-search-button-v2,.gsc-search-button-v2:hover,.gsc-search-button-v2:focus{border-color:#3079ED;background-color:#4D90FE;background-image:none;filter:none}.gsc-search-button-v2 svg{fill:#FFFFFF}.gsc-tabHeader.gsc-tabhActive,.gsc-refinementHeader.gsc-refinementhActive{color:#1A73E8;border-color:#1A73E8;background-color:#FFFFFF}.gsc-tabHeader.gsc-tabhInactive,.gsc-refinementHeader.gsc-refinementhInactive{color:#666666;border-color:#666666;background-color:#FFFFFF}.gsc-webResult.gsc-result,.gsc-results .gsc-imageResult{border-color:#1A1A2E;background-color:#1A1A2E}.gsc-webResult.gsc-result:hover{border-color:#1A1A2E;background-color:#1A1A2E}.gs-webResult.gs-result a.gs-title:link,.gs-webResult.gs-result a.gs-title:link b,.gs-imageResult a.gs-title:link,.gs-imageResult a.gs-title:link b{color:#1155CC}.gs-webResult.gs-result a.gs-title:visited,.gs-webResult.gs-result a.gs-title:visited b,.gs-imageResult a.gs-title:visited,.gs-imageResult a.gs-title:visited b{color:#1155CC}.gs-webResult.gs-result a.gs-title:hover,.gs-webResult.gs-result a.gs-title:hover b,.gs-imageResult a.gs-title:hover,.gs-imageResult a.gs-title:hover b{color:#1155CC}.gs-webResult.gs-result a.gs-title:active,.gs-webResult.gs-result a.gs-title:active b,.gs-imageResult a.gs-title:active,.gs-imageResult a.gs-title:active b{color:#1155CC}.gsc-cursor-page{color:#1155CC}a.gsc-trailing-more-results:link{color:#1155CC}.gs-webResult:not(.gs-no-results-result):not(.gs-error-result) .gs-snippet,.gs-fileFormatType{color:#FFFFFF}.gs-webResult div.gs-visibleUrl{color:#6AA84F}.gs-webResult div.gs-visibleUrl-short{color:#6AA84F}.gs-webResult div.gs-visibleUrl-short{display:none}.gs-webResult div.gs-visibleUrl-long{display:block}.gs-webResult div.gs-visibleUrl-breadcrumb{display:none}.gs-promotion div.gs-visibleUrl-short{display:none}.gs-promotion div.gs-visibleUrl-long{display:block}.gs-promotion div.gs-visibleUrl-breadcrumb{display:none}.gsc-cursor-box{border-color:#1A1A2E}.gsc-results .gsc-cursor-box .gsc-cursor-page{border-color:#666666;background-color:#FFFFFF;color:#666666}.gsc-results .gsc-cursor-box .gsc-cursor-current-page{border-color:#1A73E8;background-color:#FFFFFF;color:#1A73E8}.gsc-webResult.gsc-result.gsc-promotion{border-color:#FFFFFF;background-color:#F6F6F6}.gsc-completion-title{color:#1155CC}.gsc-completion-snippet{color:#FFFFFF}.gs-promotion a.gs-title:link,.gs-promotion a.gs-title:link *,.gs-promotion .gs-snippet a:link{color:#1155CC}.gs-promotion a.gs-title:visited,.gs-promotion a.gs-title:visited *,.gs-promotion .gs-snippet a:visited{color:#1155CC}.gs-promotion a.gs-title:hover,.gs-promotion a.gs-title:hover *,.gs-promotion .gs-snippet a:hover{color:#1155CC}.gs-promotion a.gs-title:active,.gs-promotion a.gs-title:active *,.gs-promotion .gs-snippet a:active{color:#1155CC}.gs-promotion .gs-snippet,.gs-promotion .gs-title .gs-promotion-title-right,.gs-promotion .gs-title .gs-promotion-title-right *{color:#333333}.gs-promotion .gs-visibleUrl,.gs-promotion .gs-visibleUrl-short{color:#009933}.gcsc-find-more-on-google{color:#1155CC}.gcsc-find-more-on-google-magnifier{fill:#1155CC}",
    "cse_token": "AB-tC_6AXZLV6C3JonizLrw58SGx:1699880328499",
    "isHostedPage": false,
    "exp": ["csqr", "cc"],
    "cselibVersion": "e992cd4de3c7044f",
    "usqp": "CAI\u003d"
});