/*!
 * CarHire — Editorial theme toggle
 * Reads localStorage('carhire-theme'); falls back to prefers-color-scheme.
 * Wires up the nav toggle button (#themeToggle) after DOMContentLoaded.
 * The pre-paint head script already applied the correct theme before load
 * so the button's role here is only to let the user flip + persist.
 */
(function () {
    'use strict';

    var STORAGE_KEY = 'carhire-theme';
    var root = document.documentElement;

    function currentTheme() {
        return root.getAttribute('data-theme') === 'light' ? 'light' : 'dark';
    }

    function applyTheme(next) {
        root.setAttribute('data-theme', next);
        try { localStorage.setItem(STORAGE_KEY, next); } catch (e) { /* storage blocked */ }
        syncButton(next);
    }

    function syncButton(theme) {
        var btn = document.getElementById('themeToggle');
        if (!btn) return;
        var isLight = theme === 'light';
        btn.setAttribute('aria-pressed', String(isLight));
        btn.setAttribute('aria-label',
            isLight ? 'Switch to dark theme' : 'Switch to light theme');
        var label = btn.querySelector('.ed-nav__theme-label');
        if (label) label.textContent = isLight ? 'Dark' : 'Light';
    }

    function onToggle() {
        applyTheme(currentTheme() === 'light' ? 'dark' : 'light');
    }

    document.addEventListener('DOMContentLoaded', function () {
        syncButton(currentTheme());
        var btn = document.getElementById('themeToggle');
        if (btn) btn.addEventListener('click', onToggle);
    });

    /* If the user hasn't expressed a preference, follow the OS as it changes. */
    var mql = window.matchMedia('(prefers-color-scheme: light)');
    var onSystemChange = function (e) {
        var stored;
        try { stored = localStorage.getItem(STORAGE_KEY); } catch (err) { stored = null; }
        if (stored) return; /* user has chosen; don't overwrite */
        applyTheme(e.matches ? 'light' : 'dark');
    };
    if (mql.addEventListener) mql.addEventListener('change', onSystemChange);
    else if (mql.addListener) mql.addListener(onSystemChange); /* Safari <14 */
})();
