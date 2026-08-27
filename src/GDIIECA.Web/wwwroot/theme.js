(function () {
    const storageKey = "gdi-theme";
    const themes = ["light", "soft", "dark"];
    let currentTheme = readTheme();
    let refreshPending = false;

    function readTheme() {
        try {
            const saved = localStorage.getItem(storageKey);
            return themes.includes(saved) ? saved : "light";
        } catch {
            return "light";
        }
    }

    function updateButtons(theme) {
        document.querySelectorAll("[data-theme-value]").forEach(button => {
            button.setAttribute("aria-pressed", String(button.dataset.themeValue === theme));
        });
    }

    function applyTheme(theme, persist) {
        const selected = themes.includes(theme) ? theme : "light";
        currentTheme = selected;

        if (document.documentElement.dataset.theme !== selected) {
            document.documentElement.dataset.theme = selected;
        }

        if (persist) {
            try {
                localStorage.setItem(storageKey, selected);
            } catch {
                // El tema sigue activo durante la sesión aunque el almacenamiento esté bloqueado.
            }
        }

        updateButtons(selected);
    }

    function refreshTheme() {
        if (refreshPending) {
            return;
        }

        refreshPending = true;
        queueMicrotask(() => {
            refreshPending = false;
            applyTheme(currentTheme, false);
        });
    }

    window.gdiTheme = {
        set: theme => applyTheme(theme, true),
        refresh: refreshTheme
    };

    // La navegación mejorada de Blazor actualiza el documento sin recargarlo.
    // Este observador conserva el tema si el atributo de <html> o el menú se reemplazan.
    new MutationObserver(refreshTheme).observe(document.documentElement, {
        attributes: true,
        attributeFilter: ["data-theme"],
        childList: true,
        subtree: true
    });

    window.addEventListener("pageshow", refreshTheme);
    window.addEventListener("storage", event => {
        if (event.key === storageKey) {
            applyTheme(readTheme(), false);
        }
    });

    applyTheme(currentTheme, false);
    document.addEventListener("DOMContentLoaded", refreshTheme);
})();
