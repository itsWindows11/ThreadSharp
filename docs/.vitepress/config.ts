import { DefaultTheme, defineConfig } from 'vitepress'
import fs from "fs"
import path from 'path';

const getSidebarItems = (dir: string, allItemsCollapsedByDefault: boolean | undefined = undefined) => {
  const items: DefaultTheme.SidebarItem[] = [];
  const files = fs.readdirSync(dir, { withFileTypes: true });

  for (const file of files) {
    const basename = path.basename(file.name, ".md");

    if (basename.includes("index"))
      continue;

    if (file.isDirectory()) {
      items.push({
        text: basename,
        link: `${dir}/${basename}`,
        items: getSidebarItems(`${dir}/${basename}`, allItemsCollapsedByDefault),
        collapsed: allItemsCollapsedByDefault
      });
    } else {
      items.push({
        text: basename,
        link: `${dir}/${basename}`
      });
    }
  }

  return items;
};

function docsItems(): (DefaultTheme.NavItemChildren | DefaultTheme.NavItemWithLink | DefaultTheme.SidebarItem)[] {
  return [
    {
      text: 'Getting Started',
      link: '/docs/getting-started'
    },
    {
      text: 'Threads',
      collapsed: true,
      items: [
        {
          text: "Getting the current user's threads.",
          link: '/docs/threads/get-current-user-threads'
        },
        {
          text: 'Getting threads by ID & replies.',
          link: '/docs/threads/getting-threads'
        },
        {
          text: 'Creating a new thread.',
          link: '/docs/threads/create-new-thread'
        }
      ]
    },
    {
      text: "Getting the current user's profile.",
      link: '/docs/profile'
    },
    {
      text: "Insights.",
      link: '/docs/insights'
    },
    {
      text: "Calling API endpoints unsupported by ThreadSharp.",
      link: '/docs/calling-unsupported-endpoints'
    }
  ]
}

function samplesItems() {
  return [
    { text: 'Replying To Self', link: 'https://github.com/itsWindows11/ThreadSharp/tree/main/src/Samples/ReplyToPostSample' },
    { text: 'Getting User Profile Details', link: 'https://github.com/itsWindows11/ThreadSharp/tree/main/src/Samples/GetCurrentUserProfileAndPrintDetails' },
    { text: 'Getting User Insights', link: 'https://github.com/itsWindows11/ThreadSharp/tree/main/src/Samples/GetInsightsSample' }
  ]
}

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "ThreadSharp",
  description: "A C# API wrapper for the Threads API.",
  cleanUrls: true,
  lastUpdated: true,
  base: "/ThreadSharp/",
  sitemap: {
    hostname: "https://itswindows11.github.io/ThreadSharp"
  },
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      {
        text: 'Documentation',
        items: docsItems() as (DefaultTheme.NavItemChildren | DefaultTheme.NavItemWithLink)[]
      },
      {
        text: 'Samples',
        items: samplesItems() as (DefaultTheme.NavItemComponent | DefaultTheme.NavItemChildren | DefaultTheme.NavItemWithLink)[]
      },
      { text: 'API Reference', link: '/api-reference' },
    ],

    sidebar: [
      {
        text: 'Documentation',
        collapsed: false,
        items: docsItems() as DefaultTheme.SidebarItem[]
      },
      {
        text: 'Samples',
        collapsed: false,
        items: samplesItems() as DefaultTheme.SidebarItem[]
      },
      {
        text: 'API Reference',
        collapsed: true,
        items: getSidebarItems("api-reference/", true)
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/itsWindows11/ThreadSharp' }
    ]
  }
});