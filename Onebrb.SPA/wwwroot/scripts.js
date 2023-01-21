// browser detect
var BrowserDetect = {
    init: function (userAgent, appVersion) {
        this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
        this.version = this.searchVersion(userAgent) || this.searchVersion(appVersion) || "an unknown version";
        this.OS = this.searchString(this.dataOS) || "an unknown OS";
    },
    searchString: function (data) {
        for (var i = 0; i < data.length; i++) {
            var dataString = data[i].string;
            var dataProp = data[i].prop;
            this.versionSearchString = data[i].versionSearch || data[i].identity;
            if (dataString) {
                if (dataString.indexOf(data[i].subString) != -1) {
                    return data[i].identity;
                }
            } else if (dataProp) {
                return data[i].identity;
            }
        }
    },
    searchVersion: function (dataString) {
        var index = dataString.indexOf(this.versionSearchString);
        if (index == -1) return;
        return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
    },
    dataBrowser: [{
        string: navigator.userAgent,
        subString: "Chrome",
        identity: "Chrome"
    }, {
        string: navigator.vendor,
        subString: "Apple",
        identity: "Safari",
        versionSearch: "Version"
    }, {
        prop: window.opera,
        identity: "Opera",
        versionSearch: "Version"
    }, {
        string: navigator.userAgent,
        subString: "Firefox",
        identity: "Firefox"
    }, {
        string: navigator.userAgent,
        subString: "Edge",
        identity: "Edge"
    }
    ],
    dataOS: [{
        string: navigator.platform,
        subString: "Win",
        identity: "Windows"
    }, {
        string: navigator.platform,
        subString: "Mac",
        identity: "Mac"
    }, {
        string: navigator.userAgent,
        subString: "iPhone",
        identity: "iPhone/iPod"
    }, {
        string: navigator.platform,
        subString: "Linux",
        identity: "Linux"
    }]

};
BrowserDetect.init(navigator.userAgent, navigator.appVersion);

///// mobile
var isMobile = {
    Android: function () {
        return navigator.userAgent.match(/Android/i);
    },
    BlackBerry: function () {
        return navigator.userAgent.match(/BlackBerry/i);
    },
    iOS: function () {
        return navigator.userAgent.match(/iPhone|iPad|iPod/i);
    },
    Opera: function () {
        return navigator.userAgent.match(/Opera Mini/i);
    },
    Windows: function () {
        return navigator.userAgent.match(/IEMobile/i);
    },
    any: function () {
        return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
    }
};

window.isValidBrowser = {
    get: () => (BrowserDetect.browser === 'Safari' || BrowserDetect.browser === 'Chrome' || BrowserDetect.browser === 'Mozilla' || BrowserDetect.browser === 'Edge' || BrowserDetect.browser === 'Opera')
}

window.privacyPolicy = {
    set: () => {
        (function (d, s, id) {
            var js, tjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "https://app.termly.io/embed-policy.min.js";
            tjs.parentNode.insertBefore(js, tjs);
            js.setAttribute('backgroundColor', 'white');

        }(document, 'script', 'termly-jssdk'));
    }
}

//    < div name = "termly-embed" data - id="2129a2f4-acf8-436f-a8e5-363fdab7283c" data - type="iframe" ></div >
//        <script type="text/javascript">(function(d, s, id) {
//  var js, tjs = d.getElementsByTagName(s)[0];
//            if (d.getElementById(id)) return;
//            js = d.createElement(s); js.id = id;
//            js.src = "https://app.termly.io/embed-policy.min.js";
//            tjs.parentNode.insertBefore(js, tjs);
//}(document, 'script', 'termly-jssdk'));</script>
