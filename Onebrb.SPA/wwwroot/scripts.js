export function getBlazorCulture() {
    return window.localStorage['BlazorCulture'];
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